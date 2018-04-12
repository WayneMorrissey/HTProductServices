using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using HTPSSystem.WMorr.BLL;
using HTPSSystem.WMorr.Data.Entities;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
#endregion

namespace BigPrintWebApp.ExercisePages
{
    public partial class ProductCRUD : System.Web.UI.Page
    {
        List<string> errmsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageList.DataSource = null;
            MessageList.DataBind();
            if(!IsPostBack)
            {
                ProductsDataBind();
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

        protected void ProductsDataBind()
        {
            try
            {
                ProductController prodcont = new ProductController();
                List<Product> products = prodcont.Product_List();
                products.Sort((x, y) => x.Name.CompareTo(y.Name));

                ProductList.DataSource = products;
                ProductList.DataTextField = "Name";
                ProductList.DataValueField = "ProductID";
                ProductList.DataBind();

                ProductList.Items.Insert(0, "Select... ");
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

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            MessageList.CssClass = cssclass;
            MessageList.DataSource = errormsglist;
            MessageList.DataBind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if(ProductList.SelectedIndex == 0)
            {
                // no product selected
                errmsgs.Add("Select a product to search.");
                LoadMessageDisplay(errmsgs, "alert alert-info");
            }
            else
            {
                // product selected
                try
                {
                    ProductController prodcont = new ProductController();
                    Product product = prodcont.Product_Find(int.Parse(ProductList.SelectedValue));
                    if(product == null)
                    {
                        // Product with that id not found, likely deleted since list was created
                        errmsgs.Add("Product not found, please try again.");
                        LoadMessageDisplay(errmsgs, "alert alert-warning");
                        // reset list to clear deleted product
                        // should never happen since products are not deleted, but discontinued
                        ProductsDataBind();
                    }
                    else
                    {
                        ProductID.Text = product.ProductID.ToString();
                        Name.Text = product.Name;
                        ModelNumber.Text = product.ModelNumber;
                        Discontinued.Checked = product.Discontinued;
                        DiscontinuedDate.Text = string.Format("{0:dd/MM/yyyy}", product.DiscontinuedDate);
                    }
                }
                catch (Exception ex)
                {
                    errmsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errmsgs, "alert alert-danger");
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ProductID.Text = "";
            Name.Text = "";
            ModelNumber.Text = "";
            Discontinued.Checked = false;
            DiscontinuedDate.Text = "";
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                try
                {
                    // create product instance from web form
                    Product prod = new Product();
                    prod.Name = Name.Text;
                    prod.ModelNumber = ModelNumber.Text;
                    prod.Discontinued = Discontinued.Checked;
                    if(string.IsNullOrEmpty(DiscontinuedDate.Text))
                    {
                        prod.DiscontinuedDate = null;
                    }
                    else
                    {
                        prod.DiscontinuedDate = DateTime.Parse(DiscontinuedDate.Text);
                    }

                    ProductController prodcont = new ProductController();
                    int pkey = prodcont.Product_Add(prod);

                    // if successful
                    ProductID.Text = pkey.ToString();
                    errmsgs.Add("Product " + Name.Text + " was Added");
                    LoadMessageDisplay(errmsgs, "alert alert-success");

                    // rebind data list
                    ProductsDataBind();
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

        protected void Update_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                if (string.IsNullOrEmpty(ProductID.Text))
                {
                    errmsgs.Add("Update requires you to search for a product first.");
                }
                else
                {
                    int temp = 0;
                    if(!int.TryParse(ProductID.Text, out temp))
                    {
                        errmsgs.Add("ProductID is not valid.");
                    }
                }
                if(errmsgs.Count > 0)
                {
                    LoadMessageDisplay(errmsgs, "alert alert-warning");
                }
                else
                {
                    try
                    {
                        Product prod = new Product();
                        prod.ProductID = int.Parse(ProductID.Text);
                        prod.Name = Name.Text;
                        prod.ModelNumber = ModelNumber.Text;
                        prod.Discontinued = Discontinued.Checked;
                        if (string.IsNullOrEmpty(DiscontinuedDate.Text))
                        {
                            prod.DiscontinuedDate = null;
                        }
                        else
                        {
                            prod.DiscontinuedDate = DateTime.Parse(DiscontinuedDate.Text);
                        }

                        ProductController prodcont = new ProductController();
                        int rowsAffected = prodcont.Product_Update(prod);

                        if(rowsAffected > 0)
                        {
                            errmsgs.Add("Product " + prod.Name + " was updated.");
                            LoadMessageDisplay(errmsgs, "alert alert-success");

                            ProductsDataBind();
                        }
                        else
                        {
                            errmsgs.Add("Product is no longer on file. Look up product again.");
                            LoadMessageDisplay(errmsgs, "alert alert-warning");

                            ProductsDataBind();
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
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (string.IsNullOrEmpty(ProductID.Text))
                {
                    errmsgs.Add("Delete requires you to search for a product first.");
                }
                else
                {
                    int temp = 0;
                    if (!int.TryParse(ProductID.Text, out temp))
                    {
                        errmsgs.Add("ProductID is not valid.");
                    }
                }
                if (errmsgs.Count > 0)
                {
                    LoadMessageDisplay(errmsgs, "alert alert-warning");
                }
                else
                {
                    try
                    {
                        ProductController prodcont = new ProductController();
                        Product prod = prodcont.Product_Find(int.Parse(ProductID.Text));
                        
                        int rowsAffected = prodcont.Product_Delete(prod);

                        if (rowsAffected > 0)
                        {
                            errmsgs.Add("Product " + prod.Name + " was discontinued.");
                            LoadMessageDisplay(errmsgs, "alert alert-success");

                            ProductsDataBind();
                            Discontinued.Checked = true;
                            DiscontinuedDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Today);
                        }
                        else
                        {
                            errmsgs.Add("Product is no longer on file. Look up product again.");
                            LoadMessageDisplay(errmsgs, "alert alert-warning");

                            ProductsDataBind();
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
        }
    }
}