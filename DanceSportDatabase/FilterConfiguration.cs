using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceSportDatabase
{
    class FilterConfiguration
    {

    }


    class DancerConfiguration
    {
        public string name;
        public int minHeight, maxHeight, minYear, maxYear;
        public string minClassLat, maxClassLat, minClassSt, maxClassSt;
        public string sexM, sexF; //0 or 1

        public DancerConfiguration()
        {
            //minName = "" + ('а'-1);
            name = "";
            minHeight = 100;
            maxHeight = 220;
            minYear = 1900;
            maxYear = 2030;
            minClassLat = "H";
            maxClassLat = "S";
            minClassSt = "H";
            maxClassSt = "S";
            sexM = "1";
            sexF = "1";
        }
        
    }


    class CoupleConfiguration
    {
        public string nameM, nameF;
        public int minYear, maxYear, minRating, maxRating;
        public string minClassLat, maxClassLat, minClassSt, maxClassSt;

        public CoupleConfiguration()
        {
            nameM = "";
            nameF = "";
            minYear = 1900;
            maxYear = 2030;
            minClassLat = "H";
            maxClassLat = "S";
            minClassSt = "H";
            maxClassSt = "S";
        }

    }
}
