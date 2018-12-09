﻿using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 订单的实体
    /// </summary>
  public   class Order
    {
        public Guid ID { get; set; }
        public DateTime OrderDateTime { get; set; }//订单时间
        public virtual Person Person { get; set; }//所属用户

       
        public string AddressPerson { get; set; }//收件人
        public  string Address { get; set; }//收件人地址
        public string MobilNumber { get; set; }//收件人的手机
        public  string TotalPrice { get; set; }//总价
        public string TradeNo { get; set; }//支付流水号
        public  bool PaySuccess { get; set; }//是否支付成功

        public virtual EnumOrderStatus EnumOrderStatus { get; set; }//订单的状态
        //购买专辑明细，ef中的包含关系
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        //购买专辑明细
        public Order()
        {
            ID = Guid.NewGuid();
            OrderDateTime = DateTime.Now;
            TradeNo = OrderDateTime.ToString("yyyyMMddhhmmssffff");
        }
    } 
}
 