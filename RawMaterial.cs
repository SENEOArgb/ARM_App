using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ARM_App.Model;

public partial class RawMaterial : INotifyPropertyChanged
{
    public int rawMaterialId { get; set; }

    private string nameRawMaterial { get; set; } = null!;

    public string NameRawMaterial
    {
        get { return nameRawMaterial; }
        set
        {
            nameRawMaterial = value;
            OnPropertyChanged("NameRawMaterial");
        }
    }

    private string? typeRawMaterial { get; set; }

    public string? TypeRawMaterial
    {
        get { return typeRawMaterial; }
        set
        {
            typeRawMaterial = value;
            OnPropertyChanged("TypeRawMaterial");
        }
    }

    private float? countRawMaterial { get; set; }

    public float? CountRawMaterial
    {
        get { return countRawMaterial; }
        set
        {
            countRawMaterial = value;
            OnPropertyChanged("CountRawMaterial");
        }
    }

    public RawMaterial() { }

    public RawMaterial(int rawMaterialId, string nameRawMaterial, string? typeRawMaterial, float countRawMaterial)
    {
        this.rawMaterialId = rawMaterialId;
        this.NameRawMaterial = nameRawMaterial;
        this.TypeRawMaterial = typeRawMaterial;
        this.CountRawMaterial = countRawMaterial;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
