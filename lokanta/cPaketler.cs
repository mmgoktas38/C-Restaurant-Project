using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokanta_Otomasyonu
{
    class cPaketler
    {
        #region MyRegion
        private int _ID;       
        private int _AdditionID;        
        private int _ClientId;        
        private string _Description;        
        private int _State;        
        private int _Paytypeid;        
        #endregion


        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int AdditionID
        {
            get { return _AdditionID; }
            set { _AdditionID = value; }
        }
        public int ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public int State
        {
            get { return _State; }
            set { _State = value; }
        }
        public int Paytypeid
        {
            get { return _Paytypeid; }
            set { _Paytypeid = value; }
        }
        #endregion







    }
}
