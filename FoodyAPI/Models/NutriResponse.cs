using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyAPI.Models
{
    public class NutriResponse
    {

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class CA
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class CHOCDF
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class CHOLE
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class ENERCKCAL
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class FAMS
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class FAPU
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class FASAT
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class FAT
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class FATRN
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class FE
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class FIBTG
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class FOLAC
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class FOLDFE
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class FOLFD
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class K
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class MG
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class NA
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class NIA
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class P
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class PROCNT
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class RIBF
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class SUGAR
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class SUGARAdded
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class THIA
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class TOCPHA
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class VITARAE
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class VITB12
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class VITB6A
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class VITC
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class VITD
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class VITK1
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class ZN
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class TotalNutrients
        {
            public CA CA { get; set; }
            public CHOCDF CHOCDF { get; set; }
            public CHOLE CHOLE { get; set; }
            public ENERCKCAL ENERC_KCAL { get; set; }
            public FAMS FAMS { get; set; }
            public FAPU FAPU { get; set; }
            public FASAT FASAT { get; set; }
            public FAT FAT { get; set; }
            public FATRN FATRN { get; set; }
            public FE FE { get; set; }
            public FIBTG FIBTG { get; set; }
            public FOLAC FOLAC { get; set; }
            public FOLDFE FOLDFE { get; set; }
            public FOLFD FOLFD { get; set; }
            public K K { get; set; }
            public MG MG { get; set; }
            public NA NA { get; set; }
            public NIA NIA { get; set; }
            public P P { get; set; }
            public PROCNT PROCNT { get; set; }
            public RIBF RIBF { get; set; }
            public SUGAR SUGAR { get; set; }

        }

        public class NutritionalInfo
        {
            public double calories { get; set; }
            public TotalNutrients totalNutrients { get; set; }
        }

        public class Root
        {
            public string foodName { get; set; }
            public bool hasNutritionalInfo { get; set; }
            public int imageId { get; set; }
            public NutritionalInfo nutritional_info { get; set; }
        }
    }
}
