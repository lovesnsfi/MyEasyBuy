using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;   //文件流命名空间

namespace MyEasyBuy
{
    public partial class AddGoods : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            //判断网页是否是第一次加载
            if (!Page.IsPostBack)
            {
                //绑定我们的下拉框
                List<Model.eb_category> categoryList = new BLL.eb_category().GetModelList("");
                this.Dropcategory.DataSource = categoryList;
                this.Dropcategory.DataTextField = "cname";
                this.Dropcategory.DataValueField = "cid";
                this.Dropcategory.DataBind();
            }
           
        }

        //添加商品
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            //要判断一下，是否有图片
            //如果用户选择了图片，那么，就要上传图片，保存图片
            string filepath = string.Empty;
            if (goodsimg.HasFile)
            {
                //表示选择了图片，那么用户就要保存图片
                //判断存放图片的文件夹是否存在，如果不存在，我就要创建文件夹
                if (!Directory.Exists(Server.MapPath(@"\goodsimg")))
                {
                    //不存在，则创建
                    Directory.CreateDirectory(Server.MapPath(@"\goodsimg"));
                }
                //为了防止文件的重名，我们加随机数
                
                filepath = @"\goodsimg\" +DateTime.Now.ToString("yyyyMMddHHmmss")+ rd.Next(10000).ToString()+ goodsimg.FileName;
                //图片就保存到图务器上面去了
                goodsimg.SaveAs(Server.MapPath(filepath));
            }
            Model.eb_goods model = new Model.eb_goods();
            model.gname = this.gname.Text.Trim();
            model.cid = int.Parse(this.Dropcategory.SelectedValue.ToString());
            model.offset = decimal.Parse(this.offset.Text.Trim());
            model.price = decimal.Parse(this.price.Text.Trim());   //只留2位小数
            model.publishTime = DateTime.Now;   //发布时间就是现在的时间
            model.total = int.Parse(this.total.Text.Trim());
            if (!string.IsNullOrEmpty(this.hiddenGid.Value))
            {
                //修改
            }
            else
            {
                //新增
                model.goodsimg = filepath;
                int gid = new BLL.eb_goods().Add(model);
                if (gid>0)
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this.Page, "添加成功", "GoodsList.aspx");
                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this.Page, "添加失败，请重试或联系管理员", "GoodsList.aspx");

                }

            }
        }
    }
}