/* File: PayloadController.cs
 * 
 * Revision History - Begin
 * Date                 Author      Bug #       Description 
 * February 12, 2024	RMarinas	N/A			Created.
 * Revision History - End
 */

using System.Data;
using System.Data.SqlClient;
using GOLF_WAREHOUSE_POS_WEB_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GOLF_WAREHOUSE_POS_WEB_API.Controllers
{
    [ApiController]
    public class PayloadController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PayloadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("TestConnection")]
        public string TestConnection()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.PS_DOC_HDR", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return "test";
        }
        [HttpPost]
        [Route("PostPayload")]
        public string PostPayload(PayloadModel payloadModel)
        {
            try
            {
                if (DocIdExists(payloadModel.PS_DOC_HDR.DOC_ID))
                {
                    return "The DOC_ID that you are trying to insert alredy exists.";
                }

                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    con.Open();

                    PS_DOC_HDR_insert(con, payloadModel.PS_DOC_HDR);

                    foreach (PS_DOC_HDR_TOT_Model psDocHdrTotModel in payloadModel.LST_PS_DOC_HDR_TOT)
                    {
                        PS_DOC_HDR_TOT_insert(con, payloadModel.PS_DOC_HDR.DOC_ID, psDocHdrTotModel);
                    }

                    foreach (PS_DOC_HDR_MISC_CHRG_Model psDocHdrMiscChrgModel in payloadModel.LST_PS_DOC_HDR_MISC_CHRG)
                    {
                        PS_DOC_HDR_MISC_CHRG_insert(con, payloadModel.PS_DOC_HDR.DOC_ID, psDocHdrMiscChrgModel);
                    }

                    PS_DOC_AUDIT_LOG_insert(con, payloadModel.PS_DOC_HDR, payloadModel.PS_DOC_AUDIT_LOG);

                    foreach (PS_DOC_CONTACT_Model psDocContactModel in payloadModel.LST_PS_DOC_CONTACT)
                    {
                        PS_DOC_CONTACT_insert(con, payloadModel.PS_DOC_HDR.DOC_ID, psDocContactModel);
                    }

                    foreach (PS_DOC_TAX_Model psDocTaxModel in payloadModel.LST_PS_DOC_TAX)
                    {
                        PS_DOC_TAX_insert(con, payloadModel.PS_DOC_HDR.DOC_ID, psDocTaxModel);
                    }

                    foreach (PS_DOC_LIN_Model psDocLinModel in payloadModel.LST_PS_DOC_LIN)
                    {
                        PS_DOC_LIN_insert(con, payloadModel.PS_DOC_HDR.DOC_ID, psDocLinModel);
                    }

                    PS_DOC_PMT_insert(con, payloadModel.PS_DOC_HDR.DOC_ID, payloadModel.PS_DOC_PMT);
                }

                return "Payload successfully inserted to db";
            }
            catch (Exception ex)
            {
                WriteLog(payloadModel.PS_DOC_HDR.DOC_ID, ex.Message);

                return "An error has occurred.";
            }
        }
        private void PS_DOC_HDR_insert(SqlConnection con, PS_DOC_HDR_Model psDocHdrModel)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_PS_DOC_HDR_insert", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@DOC_ID", psDocHdrModel.DOC_ID));
            cmd.Parameters.Add(new SqlParameter("@STR_ID", psDocHdrModel.STR_ID));
            cmd.Parameters.Add(new SqlParameter("@STA_ID", psDocHdrModel.STA_ID));

            cmd.Parameters.Add(new SqlParameter("@DRW_ID",
                psDocHdrModel.DRW_ID == null ? DBNull.Value : psDocHdrModel.DRW_ID));

            cmd.Parameters.Add(new SqlParameter("@DRW_SESSION_ID",
                psDocHdrModel.DRW_SESSION_ID == null ? DBNull.Value : psDocHdrModel.DRW_SESSION_ID));

            cmd.Parameters.Add(new SqlParameter("@TKT_NO", psDocHdrModel.TKT_NO));
            cmd.Parameters.Add(new SqlParameter("@DOC_TYP", psDocHdrModel.DOC_TYP));

            cmd.Parameters.Add(new SqlParameter("@CUST_NO",
                psDocHdrModel.CUST_NO == null ? DBNull.Value : psDocHdrModel.CUST_NO));

            cmd.Parameters.Add(new SqlParameter("@LINS",
                psDocHdrModel.LINS == null ? DBNull.Value : psDocHdrModel.LINS));

            cmd.Parameters.Add(new SqlParameter("@LIN_TOT", psDocHdrModel.LIN_TOT));

            cmd.Parameters.Add(new SqlParameter("@TAX_COD",
                psDocHdrModel.TAX_COD == null ? DBNull.Value : psDocHdrModel.TAX_COD));

            cmd.Parameters.Add(new SqlParameter("@CUST_PO_NO",
                psDocHdrModel.CUST_PO_NO == null ? DBNull.Value : psDocHdrModel.CUST_PO_NO));

            cmd.Parameters.Add(new SqlParameter("@SLS_REP",
                psDocHdrModel.SLS_REP == null ? DBNull.Value : psDocHdrModel.SLS_REP));

            cmd.Parameters.Add(new SqlParameter("@STK_LOC_ID",
                psDocHdrModel.STK_LOC_ID == null ? DBNull.Value : psDocHdrModel.STK_LOC_ID));

            cmd.Parameters.Add(new SqlParameter("@PRC_LOC_ID",
                psDocHdrModel.PRC_LOC_ID == null ? DBNull.Value : psDocHdrModel.PRC_LOC_ID));

            cmd.Parameters.Add(new SqlParameter("@PFT_CTR",
                psDocHdrModel.PFT_CTR == null ? DBNull.Value : psDocHdrModel.PFT_CTR));

            cmd.Parameters.Add(new SqlParameter("@VOID_USR_ID",
                psDocHdrModel.VOID_USR_ID == null ? DBNull.Value : psDocHdrModel.VOID_USR_ID));

            cmd.Parameters.Add(new SqlParameter("@VOID_REAS",
                psDocHdrModel.VOID_REAS == null ? DBNull.Value : psDocHdrModel.VOID_REAS));

            cmd.Parameters.Add(new SqlParameter("@TAX_EXEMPT_NO",
                psDocHdrModel.TAX_EXEMPT_NO == null ? DBNull.Value : psDocHdrModel.TAX_EXEMPT_NO));

            cmd.Parameters.Add(new SqlParameter("@TAX_OVRD_REAS",
                psDocHdrModel.TAX_OVRD_REAS == null ? DBNull.Value : psDocHdrModel.TAX_OVRD_REAS));

            cmd.Parameters.Add(new SqlParameter("@DOC_GUID", psDocHdrModel.DOC_GUID));

            cmd.Parameters.Add(new SqlParameter("@BILL_TO_CONTACT_ID",
                psDocHdrModel.BILL_TO_CONTACT_ID == null ? DBNull.Value : psDocHdrModel.BILL_TO_CONTACT_ID));

            cmd.Parameters.Add(new SqlParameter("@SHIP_TO_CONTACT_ID",
                psDocHdrModel.SHIP_TO_CONTACT_ID == null ? DBNull.Value : psDocHdrModel.SHIP_TO_CONTACT_ID));

            cmd.Parameters.Add(new SqlParameter("@SHIP_DAT",
                psDocHdrModel.SHIP_DAT == null ? DBNull.Value : psDocHdrModel.SHIP_DAT));

            cmd.Parameters.Add(new SqlParameter("@ERR_REF",
                psDocHdrModel.ERR_REF == null ? DBNull.Value : psDocHdrModel.ERR_REF));

            cmd.Parameters.Add(new SqlParameter("@TKT_DT",
                psDocHdrModel.TKT_DT == null ? DBNull.Value : psDocHdrModel.TKT_DT));

            cmd.Parameters.Add(new SqlParameter("@NORM_TAX_COD",
                psDocHdrModel.NORM_TAX_COD == null ? DBNull.Value : psDocHdrModel.NORM_TAX_COD));

            cmd.Parameters.Add(new SqlParameter("@REF",
                psDocHdrModel.REF == null ? DBNull.Value : psDocHdrModel.REF));

            cmd.Parameters.Add(new SqlParameter("@LST_MAINT_DT",
                psDocHdrModel.LST_MAINT_DT == null ? DBNull.Value : psDocHdrModel.LST_MAINT_DT));

            cmd.Parameters.Add(new SqlParameter("@LST_MAINT_USR_ID",
                psDocHdrModel.LST_MAINT_USR_ID == null ? DBNull.Value : psDocHdrModel.LST_MAINT_USR_ID));

            cmd.ExecuteNonQuery();
        }
        private void PS_DOC_HDR_TOT_insert(SqlConnection con, long docId, PS_DOC_HDR_TOT_Model psDocHdrTotModel)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_PS_DOC_HDR_TOT_insert", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@DOC_ID", docId));
            cmd.Parameters.Add(new SqlParameter("@TOT_TYP", psDocHdrTotModel.TOT_TYP));
            cmd.Parameters.Add(new SqlParameter("@HAS_TAX_OVRD", psDocHdrTotModel.HAS_TAX_OVRD));

            cmd.Parameters.Add(new SqlParameter("@LINS",
                psDocHdrTotModel.LINS == null ? DBNull.Value : psDocHdrTotModel.LINS));

            cmd.Parameters.Add(new SqlParameter("@SUB_TOT", psDocHdrTotModel.SUB_TOT));
            cmd.Parameters.Add(new SqlParameter("@TAX_OVRD_LINS", psDocHdrTotModel.TAX_OVRD_LINS));

            cmd.Parameters.Add(new SqlParameter("@TOT_EXT_COST",
                psDocHdrTotModel.TOT_EXT_COST == null ? DBNull.Value : psDocHdrTotModel.TOT_EXT_COST));

            cmd.Parameters.Add(new SqlParameter("@TOT_MISC", psDocHdrTotModel.TOT_MISC));
            cmd.Parameters.Add(new SqlParameter("@TAX_AMT", psDocHdrTotModel.TAX_AMT));
            cmd.Parameters.Add(new SqlParameter("@NORM_TAX_AMT", psDocHdrTotModel.NORM_TAX_AMT));
            cmd.Parameters.Add(new SqlParameter("@TOT_TND", psDocHdrTotModel.TOT_TND));
            cmd.Parameters.Add(new SqlParameter("@TOT_CHNG", psDocHdrTotModel.TOT_CHNG));
            cmd.Parameters.Add(new SqlParameter("@TOT_WEIGHT", psDocHdrTotModel.TOT_WEIGHT));
            cmd.Parameters.Add(new SqlParameter("@TOT_CUBE", psDocHdrTotModel.TOT_CUBE));
            cmd.Parameters.Add(new SqlParameter("@TOT_HDR_DISC", psDocHdrTotModel.TOT_HDR_DISC));
            cmd.Parameters.Add(new SqlParameter("@TOT_LIN_DISC", psDocHdrTotModel.TOT_LIN_DISC));
            cmd.Parameters.Add(new SqlParameter("@TOT_HDR_DISCNTBL_AMT", psDocHdrTotModel.TOT_HDR_DISCNTBL_AMT));
            cmd.Parameters.Add(new SqlParameter("@TOT_TIP_AMT", psDocHdrTotModel.TOT_TIP_AMT));

            cmd.ExecuteNonQuery();
        }
        private void PS_DOC_HDR_MISC_CHRG_insert(SqlConnection con, long docId, PS_DOC_HDR_MISC_CHRG_Model psDocHdrMiscChrgModel)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_PS_DOC_HDR_MISC_CHRG_insert", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@DOC_ID", docId));
            cmd.Parameters.Add(new SqlParameter("@TOT_TYP", psDocHdrMiscChrgModel.TOT_TYP));
            cmd.Parameters.Add(new SqlParameter("@MISC_CHRG_NO", psDocHdrMiscChrgModel.MISC_CHRG_NO));
            cmd.Parameters.Add(new SqlParameter("@MISC_TYP", psDocHdrMiscChrgModel.MISC_TYP));
            cmd.Parameters.Add(new SqlParameter("@MISC_AMT", psDocHdrMiscChrgModel.MISC_AMT));
            cmd.Parameters.Add(new SqlParameter("@MISC_PCT", psDocHdrMiscChrgModel.MISC_PCT));
            cmd.Parameters.Add(new SqlParameter("@MISC_TAX_AMT_ALLOC", psDocHdrMiscChrgModel.MISC_TAX_AMT_ALLOC));
            cmd.Parameters.Add(new SqlParameter("@MISC_NORM_TAX_AMT_ALLOC", psDocHdrMiscChrgModel.MISC_NORM_TAX_AMT_ALLOC));

            cmd.ExecuteNonQuery();
        }
        private void PS_DOC_AUDIT_LOG_insert(SqlConnection con, PS_DOC_HDR_Model psDocHdrModel, PS_DOC_AUDIT_LOG_Model psDocAuditLogModel)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_PS_DOC_AUDIT_LOG_insert", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@DOC_ID", psDocHdrModel.DOC_ID));
            cmd.Parameters.Add(new SqlParameter("@LOG_SEQ_NO", psDocAuditLogModel.LOG_SEQ_NO));
            cmd.Parameters.Add(new SqlParameter("@DOC_TYP", psDocHdrModel.DOC_TYP));
            cmd.Parameters.Add(new SqlParameter("@DOC_GUID", psDocHdrModel.DOC_GUID));
            cmd.Parameters.Add(new SqlParameter("@STR_ID", psDocHdrModel.STR_ID));
            cmd.Parameters.Add(new SqlParameter("@STA_ID", psDocHdrModel.STA_ID));
            cmd.Parameters.Add(new SqlParameter("@DRW_ID", psDocHdrModel.DRW_ID));
            cmd.Parameters.Add(new SqlParameter("@SLS_REP", psDocHdrModel.SLS_REP));
            cmd.Parameters.Add(new SqlParameter("@MACHINE_NAM", psDocAuditLogModel.MACHINE_NAM));
            cmd.Parameters.Add(new SqlParameter("@SERVER_NAM", psDocAuditLogModel.SERVER_NAM));
            cmd.Parameters.Add(new SqlParameter("@DB_NAM", psDocAuditLogModel.DB_NAM));
            cmd.Parameters.Add(new SqlParameter("@ACTIV", psDocAuditLogModel.ACTIV));
            cmd.Parameters.Add(new SqlParameter("@LOG_ENTRY", psDocAuditLogModel.LOG_ENTRY));

            cmd.ExecuteNonQuery();
        }
        private void PS_DOC_CONTACT_insert(SqlConnection con, long docId, PS_DOC_CONTACT_Model psDocContactModel)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_PS_DOC_CONTACT_insert", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@DOC_ID", docId));
            cmd.Parameters.Add(new SqlParameter("@CONTACT_ID", psDocContactModel.CONTACT_ID));

            cmd.Parameters.Add(new SqlParameter("@NAM",
                psDocContactModel.NAM == null ? DBNull.Value : psDocContactModel.NAM));

            cmd.Parameters.Add(new SqlParameter("@FST_NAM",
                psDocContactModel.FST_NAM == null ? DBNull.Value : psDocContactModel.FST_NAM));

            cmd.Parameters.Add(new SqlParameter("@LST_NAM",
                psDocContactModel.LST_NAM == null ? DBNull.Value : psDocContactModel.LST_NAM));

            cmd.Parameters.Add(new SqlParameter("@ADRS_1",
                psDocContactModel.ADRS_1 == null ? DBNull.Value : psDocContactModel.ADRS_1));

            cmd.Parameters.Add(new SqlParameter("@ADRS_2",
                psDocContactModel.ADRS_2 == null ? DBNull.Value : psDocContactModel.ADRS_2));

            cmd.Parameters.Add(new SqlParameter("@ADRS_3",
                psDocContactModel.ADRS_3 == null ? DBNull.Value : psDocContactModel.ADRS_3));

            cmd.Parameters.Add(new SqlParameter("@CITY",
                psDocContactModel.CITY == null ? DBNull.Value : psDocContactModel.CITY));

            cmd.Parameters.Add(new SqlParameter("@STATE",
                psDocContactModel.STATE == null ? DBNull.Value : psDocContactModel.STATE));

            cmd.Parameters.Add(new SqlParameter("@ZIP_COD",
                psDocContactModel.ZIP_COD == null ? DBNull.Value : psDocContactModel.ZIP_COD));

            cmd.Parameters.Add(new SqlParameter("@CNTRY",
                psDocContactModel.CNTRY == null ? DBNull.Value : psDocContactModel.CNTRY));

            cmd.Parameters.Add(new SqlParameter("@PHONE",
                psDocContactModel.PHONE == null ? DBNull.Value : psDocContactModel.PHONE));

            cmd.Parameters.Add(new SqlParameter("@ADRS_ID",
                psDocContactModel.ADRS_ID == null ? DBNull.Value : psDocContactModel.ADRS_ID));

            cmd.Parameters.Add(new SqlParameter("@EMAIL_ADRS",
                psDocContactModel.EMAIL_ADRS == null ? DBNull.Value : psDocContactModel.EMAIL_ADRS));

            cmd.Parameters.Add(new SqlParameter("@CONTCT",
                psDocContactModel.CONTCT == null ? DBNull.Value : psDocContactModel.CONTCT));

            cmd.ExecuteNonQuery();
        }
        private void PS_DOC_TAX_insert(SqlConnection con, long docId, PS_DOC_TAX_Model psDocTaxModel)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_PS_DOC_TAX_insert", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@DOC_ID", docId));
            cmd.Parameters.Add(new SqlParameter("@AUTH_COD", psDocTaxModel.AUTH_COD));
            cmd.Parameters.Add(new SqlParameter("@RUL_COD", psDocTaxModel.RUL_COD));
            cmd.Parameters.Add(new SqlParameter("@TAX_DOC_PART", psDocTaxModel.TAX_DOC_PART));

            cmd.Parameters.Add(new SqlParameter("@LIN_AMT",
                psDocTaxModel.LIN_AMT == null ? DBNull.Value : psDocTaxModel.LIN_AMT));

            cmd.Parameters.Add(new SqlParameter("@TXBL_LIN_AMT",
                psDocTaxModel.TXBL_LIN_AMT == null ? DBNull.Value : psDocTaxModel.TXBL_LIN_AMT));

            cmd.Parameters.Add(new SqlParameter("@TXBL_MISC_CHG_AMT_1",
                psDocTaxModel.TXBL_MISC_CHG_AMT_1 == null ? DBNull.Value : psDocTaxModel.TXBL_MISC_CHG_AMT_1));

            cmd.Parameters.Add(new SqlParameter("@TXBL_MISC_CHG_AMT_2",
                psDocTaxModel.TXBL_MISC_CHG_AMT_2 == null ? DBNull.Value : psDocTaxModel.TXBL_MISC_CHG_AMT_2));

            cmd.Parameters.Add(new SqlParameter("@TXBL_MISC_CHG_AMT_3",
                psDocTaxModel.TXBL_MISC_CHG_AMT_3 == null ? DBNull.Value : psDocTaxModel.TXBL_MISC_CHG_AMT_3));

            cmd.Parameters.Add(new SqlParameter("@TXBL_MISC_CHG_AMT_4",
                psDocTaxModel.TXBL_MISC_CHG_AMT_4 == null ? DBNull.Value : psDocTaxModel.TXBL_MISC_CHG_AMT_4));

            cmd.Parameters.Add(new SqlParameter("@TXBL_MISC_CHG_AMT_5",
                psDocTaxModel.TXBL_MISC_CHG_AMT_5 == null ? DBNull.Value : psDocTaxModel.TXBL_MISC_CHG_AMT_5));

            cmd.Parameters.Add(new SqlParameter("@TXBL_GFC_AMT",
                psDocTaxModel.TXBL_GFC_AMT == null ? DBNull.Value : psDocTaxModel.TXBL_GFC_AMT));

            cmd.Parameters.Add(new SqlParameter("@TXBL_SVC_AMT",
                psDocTaxModel.TXBL_SVC_AMT == null ? DBNull.Value : psDocTaxModel.TXBL_SVC_AMT));

            cmd.Parameters.Add(new SqlParameter("@TXBL_TAX_AMT",
                psDocTaxModel.TXBL_TAX_AMT == null ? DBNull.Value : psDocTaxModel.TXBL_TAX_AMT));

            cmd.Parameters.Add(new SqlParameter("@TXBL_QTY",
                psDocTaxModel.TXBL_QTY == null ? DBNull.Value : psDocTaxModel.TXBL_QTY));

            cmd.Parameters.Add(new SqlParameter("@TAX_AMT",
                psDocTaxModel.TAX_AMT == null ? DBNull.Value : psDocTaxModel.TAX_AMT));

            cmd.Parameters.Add(new SqlParameter("@NORM_TAX_AMT",
                psDocTaxModel.NORM_TAX_AMT == null ? DBNull.Value : psDocTaxModel.NORM_TAX_AMT));

            cmd.Parameters.Add(new SqlParameter("@TAX_AMT_EXACT",
                psDocTaxModel.TAX_AMT_EXACT == null ? DBNull.Value : psDocTaxModel.TAX_AMT_EXACT));

            cmd.Parameters.Add(new SqlParameter("@NORM_TAX_AMT_EXACT",
                psDocTaxModel.NORM_TAX_AMT_EXACT == null ? DBNull.Value : psDocTaxModel.NORM_TAX_AMT_EXACT));

            cmd.Parameters.Add(new SqlParameter("@TOT_TXBL_AMT",
                psDocTaxModel.TOT_TXBL_AMT == null ? DBNull.Value : psDocTaxModel.TOT_TXBL_AMT));

            cmd.ExecuteNonQuery();
        }
        private void PS_DOC_LIN_insert(SqlConnection con, long docId, PS_DOC_LIN_Model psDocLinModel)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_PS_DOC_LIN_insert", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@DOC_ID", docId));
            cmd.Parameters.Add(new SqlParameter("@LIN_SEQ_NO", psDocLinModel.LIN_SEQ_NO));
            cmd.Parameters.Add(new SqlParameter("@STR_ID", psDocLinModel.STR_ID));
            cmd.Parameters.Add(new SqlParameter("@STA_ID", psDocLinModel.STA_ID));
            cmd.Parameters.Add(new SqlParameter("@TKT_NO", psDocLinModel.TKT_NO));
            cmd.Parameters.Add(new SqlParameter("@LIN_TYP", psDocLinModel.LIN_TYP));

            cmd.Parameters.Add(new SqlParameter("@PRC",
                psDocLinModel.PRC == null ? DBNull.Value : psDocLinModel.PRC));

            cmd.Parameters.Add(new SqlParameter("@ITEM_NO", psDocLinModel.ITEM_NO));

            cmd.Parameters.Add(new SqlParameter("@DESCR",
                psDocLinModel.DESCR == null ? DBNull.Value : psDocLinModel.DESCR));

            cmd.Parameters.Add(new SqlParameter("@RETAIL_VAL",
                psDocLinModel.RETAIL_VAL == null ? DBNull.Value : psDocLinModel.RETAIL_VAL));

            cmd.Parameters.Add(new SqlParameter("@CALC_PRC",
                psDocLinModel.CALC_PRC == null ? DBNull.Value : psDocLinModel.CALC_PRC));

            cmd.Parameters.Add(new SqlParameter("@EXT_COST",
                psDocLinModel.EXT_COST == null ? DBNull.Value : psDocLinModel.EXT_COST));

            cmd.Parameters.Add(new SqlParameter("@STK_LOC_ID",
                psDocLinModel.STK_LOC_ID == null ? DBNull.Value : psDocLinModel.STK_LOC_ID));

            cmd.Parameters.Add(new SqlParameter("@REG_PRC",
                psDocLinModel.REG_PRC == null ? DBNull.Value : psDocLinModel.REG_PRC));

            cmd.Parameters.Add(new SqlParameter("@PRC_LOC_ID",
                psDocLinModel.PRC_LOC_ID == null ? DBNull.Value : psDocLinModel.PRC_LOC_ID));

            cmd.Parameters.Add(new SqlParameter("@CATEG_COD",
                psDocLinModel.CATEG_COD == null ? DBNull.Value : psDocLinModel.CATEG_COD));

            cmd.Parameters.Add(new SqlParameter("@SUBCAT_COD",
                psDocLinModel.SUBCAT_COD == null ? DBNull.Value : psDocLinModel.SUBCAT_COD));

            cmd.Parameters.Add(new SqlParameter("@ITEM_VEND_NO",
                psDocLinModel.ITEM_VEND_NO == null ? DBNull.Value : psDocLinModel.ITEM_VEND_NO));

            cmd.Parameters.Add(new SqlParameter("@QTY_SOLD", psDocLinModel.QTY_SOLD));
            cmd.Parameters.Add(new SqlParameter("@QTY_NUMER", psDocLinModel.QTY_NUMER));
            cmd.Parameters.Add(new SqlParameter("@QTY_DENOM", psDocLinModel.QTY_DENOM));

            cmd.Parameters.Add(new SqlParameter("@QTY_UNIT",
                psDocLinModel.QTY_UNIT == null ? DBNull.Value : psDocLinModel.QTY_UNIT));

            cmd.Parameters.Add(new SqlParameter("@SELL_UNIT", psDocLinModel.SELL_UNIT));

            cmd.Parameters.Add(new SqlParameter("@RET_REAS",
                psDocLinModel.RET_REAS == null ? DBNull.Value : psDocLinModel.RET_REAS));

            cmd.Parameters.Add(new SqlParameter("@EXT_PRC", psDocLinModel.EXT_PRC));
            cmd.Parameters.Add(new SqlParameter("@IS_TXBL", psDocLinModel.IS_TXBL));

            cmd.Parameters.Add(new SqlParameter("@SLS_REP",
                psDocLinModel.SLS_REP == null ? DBNull.Value : psDocLinModel.SLS_REP));

            cmd.Parameters.Add(new SqlParameter("@REF",
                psDocLinModel.REF == null ? DBNull.Value : psDocLinModel.REF));

            cmd.Parameters.Add(new SqlParameter("@ITEM_TYP", psDocLinModel.ITEM_TYP));

            cmd.Parameters.Add(new SqlParameter("@PRC_1",
                psDocLinModel.PRC_1 == null ? DBNull.Value : psDocLinModel.PRC_1));

            cmd.Parameters.Add(new SqlParameter("@QTY_DECS",
                psDocLinModel.QTY_DECS == null ? DBNull.Value : psDocLinModel.QTY_DECS));

            cmd.Parameters.Add(new SqlParameter("@PRC_DECS",
                psDocLinModel.PRC_DECS == null ? DBNull.Value : psDocLinModel.PRC_DECS));

            cmd.Parameters.Add(new SqlParameter("@BARCOD",
                psDocLinModel.BARCOD == null ? DBNull.Value : psDocLinModel.BARCOD));

            cmd.Parameters.Add(new SqlParameter("@TAX_CATEG",
                psDocLinModel.TAX_CATEG == null ? DBNull.Value : psDocLinModel.TAX_CATEG));

            cmd.Parameters.Add(new SqlParameter("@TRK_METH", psDocLinModel.TRK_METH));

            cmd.Parameters.Add(new SqlParameter("@UNIT_WEIGHT",
                psDocLinModel.UNIT_WEIGHT == null ? DBNull.Value : psDocLinModel.UNIT_WEIGHT));

            cmd.Parameters.Add(new SqlParameter("@UNIT_CUBE",
                psDocLinModel.UNIT_CUBE == null ? DBNull.Value : psDocLinModel.UNIT_CUBE));

            cmd.Parameters.Add(new SqlParameter("@LIN_GUID", psDocLinModel.LIN_GUID));

            cmd.Parameters.Add(new SqlParameter("@DIM_1_UPR",
                psDocLinModel.DIM_1_UPR == null ? DBNull.Value : psDocLinModel.DIM_1_UPR));

            cmd.Parameters.Add(new SqlParameter("@DIM_2_UPR",
                psDocLinModel.DIM_2_UPR == null ? DBNull.Value : psDocLinModel.DIM_2_UPR));

            cmd.Parameters.Add(new SqlParameter("@DIM_3_UPR",
                psDocLinModel.DIM_3_UPR == null ? DBNull.Value : psDocLinModel.DIM_3_UPR));

            cmd.Parameters.Add(new SqlParameter("@UNIT_COST",
                psDocLinModel.UNIT_COST == null ? DBNull.Value : psDocLinModel.UNIT_COST));

            cmd.Parameters.Add(new SqlParameter("@SER_NO",
                psDocLinModel.SER_NO == null ? DBNull.Value : psDocLinModel.SER_NO));

            cmd.Parameters.Add(new SqlParameter("@QTY_RET", psDocLinModel.QTY_RET));
            cmd.Parameters.Add(new SqlParameter("@GROSS_EXT_PRC", psDocLinModel.GROSS_EXT_PRC));

            cmd.Parameters.Add(new SqlParameter("@DISP_EXT_PRC",
                psDocLinModel.DISP_EXT_PRC == null ? DBNull.Value : psDocLinModel.DISP_EXT_PRC));

            cmd.Parameters.Add(new SqlParameter("@HAS_PRC_OVRD", psDocLinModel.HAS_PRC_OVRD));

            cmd.Parameters.Add(new SqlParameter("@PRC_OVRD_REAS",
                psDocLinModel.PRC_OVRD_REAS == null ? DBNull.Value : psDocLinModel.PRC_OVRD_REAS));

            cmd.Parameters.Add(new SqlParameter("@COST_OF_SLS_PCT",
                psDocLinModel.COST_OF_SLS_PCT == null ? DBNull.Value : psDocLinModel.COST_OF_SLS_PCT));

            cmd.Parameters.Add(new SqlParameter("@MIX_MATCH_COD",
                psDocLinModel.MIX_MATCH_COD == null ? DBNull.Value : psDocLinModel.MIX_MATCH_COD));

            cmd.Parameters.Add(new SqlParameter("@USR_ENTD_PRC", psDocLinModel.USR_ENTD_PRC));

            cmd.Parameters.Add(new SqlParameter("@GROSS_DISP_EXT_PRC",
               psDocLinModel.GROSS_DISP_EXT_PRC == null ? DBNull.Value : psDocLinModel.GROSS_DISP_EXT_PRC));

            cmd.Parameters.Add(new SqlParameter("@IS_DISCNTBL", psDocLinModel.IS_DISCNTBL));
            cmd.Parameters.Add(new SqlParameter("@CALC_EXT_PRC", psDocLinModel.CALC_EXT_PRC));
            cmd.Parameters.Add(new SqlParameter("@IS_WEIGHED", psDocLinModel.IS_WEIGHED));
            cmd.Parameters.Add(new SqlParameter("@TAX_AMT_ALLOC", psDocLinModel.TAX_AMT_ALLOC));
            cmd.Parameters.Add(new SqlParameter("@NORM_TAX_AMT_ALLOC", psDocLinModel.NORM_TAX_AMT_ALLOC));

            cmd.ExecuteNonQuery();
        }
        private void PS_DOC_PMT_insert(SqlConnection con, long docId, PS_DOC_PMT_Model psDocPmtModel)
        {
            SqlCommand cmd = new SqlCommand("dbo.usp_PS_DOC_PMT_insert", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@DOC_ID", docId));
            cmd.Parameters.Add(new SqlParameter("@PMT_SEQ_NO", psDocPmtModel.PMT_SEQ_NO));

            cmd.Parameters.Add(new SqlParameter("@CARD_NO",
                psDocPmtModel.CARD_NO == null ? DBNull.Value : psDocPmtModel.CARD_NO));

            cmd.Parameters.Add(new SqlParameter("@PAY_COD_TYP", psDocPmtModel.PAY_COD_TYP));
            cmd.Parameters.Add(new SqlParameter("@AMT", psDocPmtModel.AMT));
            cmd.Parameters.Add(new SqlParameter("@STR_ID", psDocPmtModel.STR_ID));
            cmd.Parameters.Add(new SqlParameter("@FINAL_PMT", psDocPmtModel.FINAL_PMT));
            cmd.Parameters.Add(new SqlParameter("@STA_ID", psDocPmtModel.STA_ID));
            cmd.Parameters.Add(new SqlParameter("@CARD_IS_NEW", psDocPmtModel.CARD_IS_NEW));
            cmd.Parameters.Add(new SqlParameter("@TKT_NO", psDocPmtModel.TKT_NO));
            cmd.Parameters.Add(new SqlParameter("@SECURE_ECOMM_TRX", psDocPmtModel.SECURE_ECOMM_TRX));
            cmd.Parameters.Add(new SqlParameter("@PMT_LIN_TYP", psDocPmtModel.PMT_LIN_TYP));

            cmd.Parameters.Add(new SqlParameter("@PAY_COD",
                psDocPmtModel.PAY_COD == null ? DBNull.Value : psDocPmtModel.PAY_COD));

            cmd.Parameters.Add(new SqlParameter("@PAY_DAT",
                psDocPmtModel.PAY_DAT == null ? DBNull.Value : psDocPmtModel.PAY_DAT));

            cmd.Parameters.Add(new SqlParameter("@DEP_LIN_COPIED_TO_REL_DOC", psDocPmtModel.DEP_LIN_COPIED_TO_REL_DOC));
            cmd.Parameters.Add(new SqlParameter("@HOME_CURNCY_AMT", psDocPmtModel.HOME_CURNCY_AMT));
            cmd.Parameters.Add(new SqlParameter("@EXCH_LOSS", psDocPmtModel.EXCH_LOSS));

            Byte[] imgtype = { 0 };
            cmd.Parameters.Add(new SqlParameter("@SIG_IMG",
                psDocPmtModel.SIG_IMG == null ? imgtype : psDocPmtModel.SIG_IMG));

            cmd.Parameters.Add(new SqlParameter("@SWIPED", psDocPmtModel.SWIPED));

            cmd.Parameters.Add(new SqlParameter("@SIG_IMG_VECTOR",
                psDocPmtModel.SIG_IMG_VECTOR == null ? imgtype : psDocPmtModel.SIG_IMG_VECTOR));

            cmd.Parameters.Add(new SqlParameter("@EDC_AUTH_COD",
                psDocPmtModel.EDC_AUTH_COD == null ? DBNull.Value : psDocPmtModel.EDC_AUTH_COD));

            cmd.Parameters.Add(new SqlParameter("@DESCR",
                psDocPmtModel.DESCR == null ? DBNull.Value : psDocPmtModel.DESCR));

            cmd.Parameters.Add(new SqlParameter("@EDC_AUTH_FLG", psDocPmtModel.EDC_AUTH_FLG));
            cmd.Parameters.Add(new SqlParameter("@CURNCY_COD", psDocPmtModel.CURNCY_COD));

            cmd.Parameters.Add(new SqlParameter("@EBT_BAL_REMAIN",
                psDocPmtModel.EBT_BAL_REMAIN == null ? DBNull.Value : psDocPmtModel.EBT_BAL_REMAIN));

            cmd.Parameters.Add(new SqlParameter("@EXCH_RATE_NUMER", psDocPmtModel.EXCH_RATE_NUMER));
            cmd.Parameters.Add(new SqlParameter("@EXCH_RATE_DENOM", psDocPmtModel.EXCH_RATE_DENOM));

            cmd.Parameters.Add(new SqlParameter("@LOY_PTS_RDM",
                psDocPmtModel.LOY_PTS_RDM == null ? DBNull.Value : psDocPmtModel.LOY_PTS_RDM));

            cmd.Parameters.Add(new SqlParameter("@SVC_BAL_REMAIN",
                psDocPmtModel.SVC_BAL_REMAIN == null ? DBNull.Value : psDocPmtModel.SVC_BAL_REMAIN));

            cmd.Parameters.Add(new SqlParameter("@SVC_REF_NO",
                psDocPmtModel.SVC_REF_NO == null ? DBNull.Value : psDocPmtModel.SVC_REF_NO));

            cmd.Parameters.Add(new SqlParameter("@EDC_AUTH_RESP",
                psDocPmtModel.EDC_AUTH_RESP == null ? DBNull.Value : psDocPmtModel.EDC_AUTH_RESP));

            cmd.Parameters.Add(new SqlParameter("@ROUND_GAIN_LOSS", psDocPmtModel.ROUND_GAIN_LOSS));
            cmd.Parameters.Add(new SqlParameter("@HOME_CURNCY_ROUND_GAIN_LOSS", psDocPmtModel.HOME_CURNCY_ROUND_GAIN_LOSS));
            cmd.Parameters.Add(new SqlParameter("@TIP_AMT", psDocPmtModel.TIP_AMT));
            cmd.Parameters.Add(new SqlParameter("@GFC_AUTHED", psDocPmtModel.GFC_AUTHED));

            cmd.ExecuteNonQuery();
        }
        private void WriteLog(long docId, string remarks)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.usp_LOGS_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DOC_ID", docId));
                cmd.Parameters.Add(new SqlParameter("@REMARKS", remarks));
                cmd.ExecuteNonQuery();
            }
        }
        private bool DocIdExists(long docId)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM dbo.PS_DOC_HDR WHERE DOC_ID = " + docId, con);
                int TotalRows = (int)cmd.ExecuteScalar();
                return TotalRows > 0;
            }
        }
    }
}
