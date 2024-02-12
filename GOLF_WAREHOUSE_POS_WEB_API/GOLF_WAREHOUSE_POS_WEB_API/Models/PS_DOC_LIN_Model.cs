/* File: PS_DOC_LIN_Model.cs
 * 
 * Revision History - Begin
 * Date                 Author      Bug #       Description 
 * February 12, 2024	RMarinas	N/A			Created.
 * Revision History - End
 */

namespace GOLF_WAREHOUSE_POS_WEB_API.Models
{
    public class PS_DOC_LIN_Model
    {
        public int LIN_SEQ_NO { get; set; }
        public string STR_ID { get; set; }
        public string STA_ID { get; set; }
        public string TKT_NO { get; set; }
        public string LIN_TYP { get; set; }
        public decimal? PRC { get; set; }
        public string ITEM_NO { get; set; }
        public string? DESCR { get; set; }
        public decimal? RETAIL_VAL { get; set; }
        public decimal? CALC_PRC { get; set; }
        public decimal? EXT_COST { get; set; }
        public string? STK_LOC_ID { get; set; }
        public decimal? REG_PRC { get; set; }
        public string? PRC_LOC_ID { get; set; }
        public string? CATEG_COD { get; set; }
        public string? SUBCAT_COD { get; set; }
        public string? ITEM_VEND_NO { get; set; }
        public decimal QTY_SOLD { get; set; }
        public decimal QTY_NUMER { get; set; }
        public decimal QTY_DENOM { get; set; }
        public string? QTY_UNIT { get; set; }
        public string SELL_UNIT { get; set; }
        public string? RET_REAS { get; set; }
        public decimal EXT_PRC { get; set; }
        public string IS_TXBL { get; set; }
        public string? SLS_REP { get; set; }
        public string? REF { get; set; }
        public string ITEM_TYP { get; set; }
        public decimal? PRC_1 { get; set; }
        public int? QTY_DECS { get; set; }
        public int? PRC_DECS { get; set; }
        public string? BARCOD { get; set; }
        public string? TAX_CATEG { get; set; }
        public string TRK_METH { get; set; }
        public decimal? UNIT_WEIGHT { get; set; }
        public decimal? UNIT_CUBE { get; set; }
        public string LIN_GUID { get; set; }
        public string? DIM_1_UPR { get; set; }
        public string? DIM_2_UPR { get; set; }
        public string? DIM_3_UPR { get; set; }
        public decimal? UNIT_COST { get; set; }
        public string? SER_NO { get; set; }
        public decimal QTY_RET { get; set; }
        public decimal GROSS_EXT_PRC { get; set; }
        public decimal? DISP_EXT_PRC { get; set; }
        public string HAS_PRC_OVRD { get; set; }
        public string? PRC_OVRD_REAS { get; set; }
        public decimal? COST_OF_SLS_PCT { get; set; }
        public string? MIX_MATCH_COD { get; set; }
        public string USR_ENTD_PRC { get; set; }
        public decimal? GROSS_DISP_EXT_PRC { get; set; }
        public string IS_DISCNTBL { get; set; }
        public decimal CALC_EXT_PRC { get; set; }
        public string IS_WEIGHED { get; set; }
        public decimal TAX_AMT_ALLOC { get; set; }
        public decimal NORM_TAX_AMT_ALLOC { get; set; }
    }
}
