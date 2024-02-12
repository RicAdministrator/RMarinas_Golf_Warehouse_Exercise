/* File: PS_DOC_TAX_Model.cs
 * 
 * Revision History - Begin
 * Date                 Author      Bug #       Description 
 * February 12, 2024	RMarinas	N/A			Created.
 * Revision History - End
 */

namespace GOLF_WAREHOUSE_POS_WEB_API.Models
{
    public class PS_DOC_TAX_Model
    {
        public string AUTH_COD { get; set; }
        public string RUL_COD { get; set; }
        public string TAX_DOC_PART { get; set; }
        public decimal? LIN_AMT { get; set; }
        public decimal? TXBL_LIN_AMT { get; set; }
        public decimal? TXBL_MISC_CHG_AMT_1 { get; set; }
        public decimal? TXBL_MISC_CHG_AMT_2 { get; set; }
        public decimal? TXBL_MISC_CHG_AMT_3 { get; set; }
        public decimal? TXBL_MISC_CHG_AMT_4 { get; set; }
        public decimal? TXBL_MISC_CHG_AMT_5 { get; set; }
        public decimal? TXBL_GFC_AMT { get; set; }
        public decimal? TXBL_SVC_AMT { get; set; }
        public decimal? TXBL_TAX_AMT { get; set; }
        public decimal? TXBL_QTY { get; set; }
        public decimal? TAX_AMT { get; set; }
        public decimal? NORM_TAX_AMT { get; set; }
        public decimal? TAX_AMT_EXACT { get; set; }
        public decimal? NORM_TAX_AMT_EXACT { get; set; }
        public decimal? TOT_TXBL_AMT { get; set; }
    }
}
