/* File: PS_DOC_PMT_Model.cs
 * 
 * Revision History - Begin
 * Date                 Author      Bug #       Description 
 * February 12, 2024	RMarinas	N/A			Created.
 * Revision History - End
 */

namespace GOLF_WAREHOUSE_POS_WEB_API.Models
{
    public class PS_DOC_PMT_Model
    {
        public int PMT_SEQ_NO { get; set; }
        public string? CARD_NO { get; set; }
        public string PAY_COD_TYP { get; set; }
        public decimal AMT { get; set; }
        public string STR_ID { get; set; }
        public string FINAL_PMT { get; set; }
        public string STA_ID { get; set; }
        public string CARD_IS_NEW { get; set; }
        public string TKT_NO { get; set; }
        public string SECURE_ECOMM_TRX { get; set; }
        public string PMT_LIN_TYP { get; set; }
        public string? PAY_COD { get; set; }
        public DateTime? PAY_DAT { get; set; }
        public string DEP_LIN_COPIED_TO_REL_DOC { get; set; }
        public decimal HOME_CURNCY_AMT { get; set; }
        public decimal EXCH_LOSS { get; set; }
        public byte[]? SIG_IMG { get; set; }
        public string SWIPED { get; set; }
        public byte[]? SIG_IMG_VECTOR { get; set; }
        public string? EDC_AUTH_COD { get; set; }
        public string? DESCR { get; set; }
        public string EDC_AUTH_FLG { get; set; }
        public string CURNCY_COD { get; set; }
        public decimal? EBT_BAL_REMAIN { get; set; }
        public decimal EXCH_RATE_NUMER { get; set; }
        public decimal EXCH_RATE_DENOM { get; set; }
        public int? LOY_PTS_RDM { get; set; }
        public decimal? SVC_BAL_REMAIN { get; set; }
        public string? SVC_REF_NO { get; set; }
        public string? EDC_AUTH_RESP { get; set; }
        public decimal ROUND_GAIN_LOSS { get; set; }
        public decimal HOME_CURNCY_ROUND_GAIN_LOSS { get; set; }
        public decimal TIP_AMT { get; set; }
        public string GFC_AUTHED { get; set; }
    }
}
