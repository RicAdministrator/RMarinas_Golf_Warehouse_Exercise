/* File: PS_DOC_HDR_Model.cs
 * 
 * Revision History - Begin
 * Date                 Author      Bug #       Description 
 * February 12, 2024	RMarinas	N/A			Created.
 * Revision History - End
 */

namespace GOLF_WAREHOUSE_POS_WEB_API.Models
{
    public class PS_DOC_HDR_Model
    {
        public long DOC_ID { get; set; }
        public string STR_ID { get; set; }
        public string STA_ID { get; set; }
        public string? DRW_ID { get; set; }
        public long? DRW_SESSION_ID { get; set; }
        public string TKT_NO { get; set; }
        public string DOC_TYP { get; set; }
        public string? CUST_NO { get; set; }
        public int? LINS { get; set; }
        public decimal LIN_TOT { get; set; }
        public string? TAX_COD { get; set; }
        public string? CUST_PO_NO { get; set; }
        public string? SLS_REP { get; set; }
        public string? STK_LOC_ID { get; set; }
        public string? PRC_LOC_ID { get; set; }
        public string? PFT_CTR { get; set; }
        public string? VOID_USR_ID { get; set; }
        public string? VOID_REAS { get; set; }
        public string? TAX_EXEMPT_NO { get; set; }
        public string? TAX_OVRD_REAS { get; set; }
        public string DOC_GUID { get; set; }
        public int? BILL_TO_CONTACT_ID { get; set; }
        public int? SHIP_TO_CONTACT_ID { get; set; }
        public DateTime? SHIP_DAT { get; set; }
        public string? ERR_REF { get; set; }
        public DateTime? TKT_DT { get; set; }
        public string? NORM_TAX_COD { get; set; }
        public string? REF { get; set; }
        public DateTime? LST_MAINT_DT { get; set; }
        public string? LST_MAINT_USR_ID { get; set; }
    }
}
