using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using HTPSSystem.WMorr.Data.Entities;
using HTPSSystem.WMorr.BLL;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
#endregion

namespace BigPrintWebApp.ExercisePages
{
    public partial class ProductRegistrations : System.Web.UI.Page
    {
        List<string> errmsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageList.DataSource = null;
            MessageList.DataBind();
            if (!IsPostBack)
            {
                ProductDataBind();
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (ProductList.SelectedIndex == 0)
            {
                errmsgs.Add("You must select a product to search.");
                LoadMessageDisplay(errmsgs, "alert alert-warning");
            }
            else
            {
                try
                {
                    Product prod = new Product();
                    ProductController prodcont = new ProductController();
                    prod = prodcont.Product_Find(int.Parse(ProductList.SelectedValue));
                    if(prod == null)
                    {
                        errmsgs.Add("That product can no longer be found. Please try again.");
                        LoadMessageDisplay(errmsgs, "alert alert-warning");
                        ProductDataBind();
                    }
                    else
                    {
                        ProductName.Text = prod.Name;
                        ModelNumber.Text = prod.ModelNumber;
                        Discontinued.Checked = prod.Discontinued;
                        DiscontinuedDate.Text = string.Format("{0:MMM dd, yyyy}", prod.DiscontinuedDate);

                        List<Registration> regs = new List<Registration>();
                        RegistrationController regcont = new RegistrationController();
                        regs = regcont.Registration_GetByProduct(prod.ProductID);
                        RegistrationsGrid.DataSource = regs;
                        RegistrationsGrid.DataBind();
                    }
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errmsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errmsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errmsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errmsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errmsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errmsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errmsgs, "alert alert-danger");
                }
            }
        }

        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void LoadMessageDisplay(List<string> errmsgs, string style)
        {
            MessageList.CssClass = style;
            MessageList.DataSource = errmsgs;
            MessageList.DataBind();
        }

        protected void ProductDataBind()
        {
            try
            {
                List<Product> prods = new List<Product>();
                ProductController prodcont = new ProductController();
                prods = prodcont.Product_List();
                prods.Sort((x, y) => x.Name.CompareTo(y.Name));
                ProductList.DataSource = prods;
                ProductList.DataTextField = "Name";
                ProductList.DataValueField = "ProductID";
                ProductList.DataBind();
                ProductList.Items.Insert(0, "Select a product...");
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                if (updateException.InnerException != null)
                {
                    errmsgs.Add(updateException.InnerException.Message.ToString());
                }
                else
                {
                    errmsgs.Add(updateException.Message);
                }
                LoadMessageDisplay(errmsgs, "alert alert-danger");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        errmsgs.Add(validationError.ErrorMessage);
                    }
                }
                LoadMessageDisplay(errmsgs, "alert alert-danger");
            }
            catch (Exception ex)
            {
                errmsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errmsgs, "alert alert-danger");
            }
        }

        protected void RegistrationsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RegistrationsGrid.PageIndex = e.NewPageIndex;
            Search_Click(sender, new EventArgs());
        }
    }
}