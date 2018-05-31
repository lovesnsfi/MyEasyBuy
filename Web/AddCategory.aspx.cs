using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEasyBuy
{
    public partial class AddCategory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                string cid = Request.QueryString["cid"] == null ? "" : Request.QueryString["cid"].ToString();
                this.hiddenCid.Value = cid;
                if (!string.IsNullOrEmpty(cid))
                {
                    //判断是修改
                    this.lbtitle.Text = "商品分类管理---->>分类修改";
                    this.btnAdd.Text = "修改";
                    InitData();   //加载修改的数据
                }
                else
                {
                    //新增
                }

            }
        }

        //修改的时候，初始化数据
        private void InitData()
        {
            //拿到了商品分类的id
           
            int cid = int.Parse(this.hiddenCid.Value.ToString());
            Model.eb_category model = new BLL.eb_category().GetModel(cid);
            if (model!=null)
            {
                //表示数据还存在
                this.cname.Text = model.cname;
                this.summary.Text = model.summary;
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this.Page, "数据不存在", "CategoryList.aspx");
            }

        }

        //新增按钮  或 修改按钮
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //在点击保存的时候，怎么样去判断这个操作是新增还是修改呢
            Model.eb_category model = new Model.eb_category();
            model.cname = this.cname.Text.Trim();
            model.summary = this.summary.Text.Trim();

            if (!string.IsNullOrEmpty(this.hiddenCid.Value))
            {
                //修改
                model.cid = int.Parse(this.hiddenCid.Value);
                bool flag= new BLL.eb_category().Update(model);
                if (flag)
                {
                    //修改成功
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this.Page, "修改成功", "CategoryList.aspx");
                }
                else
                {
                    //修改失败
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this.Page, "修改失败，请重试或联系管理员", "CategoryList.aspx");
                }
            }
            else
            {
                //新增
                int cid = new BLL.eb_category().Add(model);
                if (cid > 0)
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this.Page, "添加成功", "CategoryList.aspx");
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this.Page, "添加失败，请重试或联系管理员");
                }
            }
           
        }
    }
}