using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEasyBuy
{
    public partial class GoodsList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            //查询数据
            if (!Page.IsPostBack)
            {
                #region 通过数据库内联查询
                //DataTable dt = new BLL.eb_goods().GetTableWidthCname("");
                //this.rp_goodsList.DataSource = dt;
                //this.rp_goodsList.DataBind(); 
                #endregion

                List<Model.eb_goods> listGoods = new BLL.eb_goods().GetModelList("");
                this.rp_goodsList.DataSource = listGoods.OrderBy(g=>g.gid).Take(10);
                this.rp_goodsList.DataBind();
                this.lbPageIndex.Text = "1";
                this.lbSumPage.Text = Math.Ceiling( Convert.ToDouble(listGoods.Count) / Convert.ToDouble(10)).ToString();

              
            }
        }

        //上一页

        protected void LbuttonPrePage_Click(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(this.hiddenPageIndex.Value);
            pageIndex--;
            if (pageIndex<=0)
            {
                pageIndex = 1;
            }
            double sumCount = new BLL.eb_goods().GetRecordCount("");  //拿到总记录数
            double pageSize = 10;  //页容量
            double sumPage = Math.Ceiling(sumCount / pageSize);  //计算总页数
            DataSet ds = new BLL.eb_goods().GetListByPage("", "gid", Convert.ToInt32((pageIndex - 1) * pageSize) + 1, Convert.ToInt32(pageIndex * pageSize));
            this.rp_goodsList.DataSource = ds.Tables[0];
            this.rp_goodsList.DataBind();
            this.lbPageIndex.Text = pageIndex.ToString();
            this.lbSumPage.Text = sumPage.ToString();

        }

        /// <summary>
        /// 下一页
        /// </summary>
        protected void LbuttonNextPage_Click(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(this.hiddenPageIndex.Value);
            pageIndex++;
            //先获取总记录数
            double sumCount = new BLL.eb_goods().GetRecordCount("");  //拿到总记录数
            double pageSize = 10;  //页容量
            double sumPage = Math.Ceiling(sumCount / pageSize);  //计算总页数
            if (pageIndex >= sumPage)
            {
                pageIndex = Convert.ToInt32(sumPage);
            }
            DataSet ds = new BLL.eb_goods().GetListByPage("", "gid", Convert.ToInt32((pageIndex - 1) * pageSize) + 1, Convert.ToInt32(pageIndex * pageSize));
            this.rp_goodsList.DataSource = ds.Tables[0];
            this.rp_goodsList.DataBind();
            this.lbPageIndex.Text = pageIndex.ToString();
            this.lbSumPage.Text = sumPage.ToString();
        }
    }
}