using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;
using System.Data;


namespace BLL
{
    public class gsms_ItemManager
    {
        gsms_ItemServer IS = new gsms_ItemServer();

        public int add_Item(gsms_Item item)
        {
            return gsms_ItemServer.add_Item(item);
        }
    }
}
