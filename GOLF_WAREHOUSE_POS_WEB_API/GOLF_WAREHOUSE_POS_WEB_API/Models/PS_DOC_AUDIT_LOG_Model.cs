/* File: PS_DOC_AUDIT_LOG_Model.cs
 * 
 * Revision History - Begin
 * Date                 Author      Bug #       Description 
 * February 12, 2024	RMarinas	N/A			Created.
 * Revision History - End
 */

namespace GOLF_WAREHOUSE_POS_WEB_API.Models
{
    public class PS_DOC_AUDIT_LOG_Model
    {
        public int LOG_SEQ_NO {  get; set; }
        public string MACHINE_NAM { get; set; }
        public string SERVER_NAM { get; set; }
        public string DB_NAM { get; set; }
        public string ACTIV {  get; set; }
        public string LOG_ENTRY { get; set; }
    }
}
