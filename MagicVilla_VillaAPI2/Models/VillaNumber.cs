using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI2.Models
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //will be DB generated. We do not want DB option to be generated, as the villa num is provided by user
        public int VillaNo { get; set; }

      //  [ForeignKey("Villa")]
      //  public int VillaID { get; set; } //must create navigation property to use foreignkey

       // public Villa Villa { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
