using System;
using System.Collections.Generic;
using System.Text;

namespace GenHelper.Constanta
{
    public class ConstantaHelper
    {
        private static ConstantaHelper instance;
        public ConstantaHelper()
        {

        }
        public static ConstantaHelper GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new ConstantaHelper();
                return instance;
            }
        }
        public string LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }
}
