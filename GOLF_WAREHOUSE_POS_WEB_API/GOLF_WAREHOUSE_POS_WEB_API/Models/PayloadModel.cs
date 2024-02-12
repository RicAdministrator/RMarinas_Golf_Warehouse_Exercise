/* File: PayloadModel.cs
 * 
 * Revision History - Begin
 * Date                 Author      Bug #       Description 
 * February 12, 2024	RMarinas	N/A			Created.
 * Revision History - End
 */

namespace GOLF_WAREHOUSE_POS_WEB_API.Models
{
    public class PayloadModel
    {
        public PS_DOC_HDR_Model PS_DOC_HDR { get; set; }
        public List<PS_DOC_HDR_TOT_Model> LST_PS_DOC_HDR_TOT { get; set; }
        public List<PS_DOC_HDR_MISC_CHRG_Model> LST_PS_DOC_HDR_MISC_CHRG { get; set; }
        public PS_DOC_AUDIT_LOG_Model PS_DOC_AUDIT_LOG { get; set; }
        public List<PS_DOC_CONTACT_Model> LST_PS_DOC_CONTACT { get; set; }
        public List<PS_DOC_TAX_Model> LST_PS_DOC_TAX { get; set; }
        public List<PS_DOC_LIN_Model> LST_PS_DOC_LIN { get; set; }
        public PS_DOC_PMT_Model PS_DOC_PMT { get; set; }
    }
}
