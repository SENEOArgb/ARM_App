using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ARM_App.Model;

public partial class Product : INotifyPropertyChanged
{
    public int productId { get; set; }

    private string productName { get; set; } = null!;

    public string ProductName
    {
        get { return productName; }
        set
        {
            productName = value;
            OnPropertyChanged("ProductName");
        }
    }

    private string? productCategory { get; set; }

    public string? ProductCategory
    {
        get { return productCategory; }
        set
        {
            productCategory = value;
            OnPropertyChanged("ProductCategory");
        }
    }

    private decimal productSalary { get; set; }

    public decimal ProductSalary
    {
        get { return productSalary; }
        set
        {
            productSalary = value;
            OnPropertyChanged("ProductSalary");
        }
    }

    private DateOnly? expirationDate { get; set; }

    public DateOnly? ExpirationDate
    {
        get { return expirationDate; }
        set
        {
            expirationDate = value;
            OnPropertyChanged("ExpirationDate");
        }
    }

    private int? countProduct { get; set; }

    public int? CountProduct
    {
        get { return countProduct; }
        set
        {
            countProduct = value;
            OnPropertyChanged("CountProduct");
        }
    }

    public Product() { }

    public Product(int productId, string productName, string? productCategory, decimal productSalary, DateOnly? expirationDate, int? countProduct)
    {
        this.productId = productId;
        this.ProductName = productName;
        this.ProductCategory = productCategory;
        this.ProductSalary = productSalary;
        this.ExpirationDate = expirationDate;
        this.CountProduct = countProduct;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
