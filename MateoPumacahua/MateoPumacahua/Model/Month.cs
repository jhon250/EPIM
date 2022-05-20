using System;
using System.Collections.Generic;
using System.Text;

namespace MateoPumacahua.Model
{
    public class Month
    {
        public string Mes_Name { get; set; }
        
        public Day Dia_1 { get; set; }
        public Day Dia_2 { get; set; }
        public Day Dia_3 { get; set; }
        public Day Dia_4 { get; set; }
        public Day Dia_5 { get; set; }
        public Day Dia_6 { get; set; }
        public Day Dia_7 { get; set; }
        public Day Dia_8 { get; set; }
        public Day Dia_9 { get; set; }
        public Day Dia_10 { get; set; }
        public Day Dia_11 { get; set; }
        public Day Dia_12 { get; set; }
        public Day Dia_13 { get; set; }
        public Day Dia_14 { get; set; }
        public Day Dia_15 { get; set; }
        public Day Dia_16 { get; set; }
        public Day Dia_17 { get; set; }
        public Day Dia_18 { get; set; }
        public Day Dia_19 { get; set; }
        public Day Dia_20 { get; set; }
        public Day Dia_21 { get; set; }
        public Day Dia_22 { get; set; }
        public Day Dia_23 { get; set; }
        public Day Dia_24 { get; set; }
        public Day Dia_25 { get; set; }
        public Day Dia_26 { get; set; }
        public Day Dia_27 { get; set; }
        public Day Dia_28 { get; set; }
        public Day Dia_29 { get; set; }
        public Day Dia_30 { get; set; }
        public Day Dia_31 { get; set; }
        public Day Dia_32 { get; set; }
    }

    public class Day
    {
        public string IdDia { get; set; }   
        public string Mes { get; set; }
        public string Fecha { get; set; }
        public string Presente { get; set; }
        public string Tarde { get; set; }
        public string Falta { get; set; }
    }
}
