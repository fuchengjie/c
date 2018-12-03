using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1611030057付成杰.publicClass
{
    class tb_ThGoodsInfo
    {
        private string ThGoodsID;
        private string KcID;
        private string GoodsId;
        private string SellID;
        private string empID;
        private string ThGoodsName;
        private int ThGoodsNum;
        private DateTime ThGoodsTime;
        private decimal ThGoodsPrice;
        private decimal ThNeedprice;
        private decimal ThHasPay;
        private string ThGoodsResult;

        public string ThGoodsID1
        {
            get
            {
                return ThGoodsID;
            }

            set
            {
                ThGoodsID = value;
            }
        }

        public string KcID1
        {
            get
            {
                return KcID;
            }

            set
            {
                KcID = value;
            }
        }

        public string GoodsId1
        {
            get
            {
                return GoodsId;
            }

            set
            {
                GoodsId = value;
            }
        }

        public string SellID1
        {
            get
            {
                return SellID;
            }

            set
            {
                SellID = value;
            }
        }

        public string EmpID
        {
            get
            {
                return empID;
            }

            set
            {
                empID = value;
            }
        }

        public string ThGoodsName1
        {
            get
            {
                return ThGoodsName;
            }

            set
            {
                ThGoodsName = value;
            }
        }

        public int ThGoodsNum1
        {
            get
            {
                return ThGoodsNum;
            }

            set
            {
                ThGoodsNum = value;
            }
        }

        public DateTime ThGoodsTime1
        {
            get
            {
                return ThGoodsTime;
            }

            set
            {
                ThGoodsTime = value;
            }
        }

        public decimal ThGoodsPrice1
        {
            get
            {
                return ThGoodsPrice;
            }

            set
            {
                ThGoodsPrice = value;
            }
        }

        public decimal ThNeedprice1
        {
            get
            {
                return ThNeedprice;
            }

            set
            {
                ThNeedprice = value;
            }
        }

        public decimal ThHasPay1
        {
            get
            {
                return ThHasPay;
            }

            set
            {
                ThHasPay = value;
            }
        }

        public string ThGoodsResult1
        {
            get
            {
                return ThGoodsResult;
            }

            set
            {
                ThGoodsResult = value;
            }
        }

        public tb_ThGoodsInfo(string thGoodsID, string kcID, string goodsId, string sellID, string empID, string thGoodsName, int thGoodsNum, DateTime thGoodsTime, decimal thGoodsPrice, decimal thNeedprice, decimal thHasPay, string thGoodsResult)
        {
            ThGoodsID1 = thGoodsID;
            KcID1 = kcID;
            GoodsId1 = goodsId;
            SellID1 = sellID;
            EmpID = empID;
            ThGoodsName1 = thGoodsName;
            ThGoodsNum1 = thGoodsNum;
            ThGoodsTime1 = thGoodsTime;
            ThGoodsPrice1 = thGoodsPrice;
            ThNeedprice1 = thNeedprice;
            ThHasPay1 = thHasPay;
            ThGoodsResult1 = thGoodsResult;
        }
    }
}
