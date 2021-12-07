namespace HalloDatenbank
{
    internal class HalloKlassen
    {
        public string VollerNamer //read only property
        {
            get { return $"{Ziffer} {GetZahl()}"; }
        }



        private int? ziffer; //backing field
        public int? Ziffer //full property
        {
            get { return ziffer; }
            set { ziffer = value; }
        }

        public HalloKlassen()
        {
            ziffer = null;

            int elf = 111;

            SetZahl(ref elf);

            Console.WriteLine(GetZahl());

            Ziffer = 12;
            Console.WriteLine(Ziffer);
        }


        private int zahl = 12;
        public int GetZahl() //getter
        {
            return zahl;
        }

        internal void SetZahl(ref int value) //setting
        {

            if (value < 0)
                throw new ArgumentOutOfRangeException("value");
            zahl = value;
        }
    }
}
