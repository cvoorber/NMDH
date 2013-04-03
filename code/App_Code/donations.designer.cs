﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="cvoorber")]
public partial class donationsDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void Insertstate_or_province(state_or_province instance);
  partial void Updatestate_or_province(state_or_province instance);
  partial void Deletestate_or_province(state_or_province instance);
  partial void Insertbase_country(base_country instance);
  partial void Updatebase_country(base_country instance);
  partial void Deletebase_country(base_country instance);
  partial void Insertndmh_donation(ndmh_donation instance);
  partial void Updatendmh_donation(ndmh_donation instance);
  partial void Deletendmh_donation(ndmh_donation instance);
  #endregion
	
	public donationsDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["cvoorberConnectionString1"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public donationsDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public donationsDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public donationsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public donationsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<state_or_province> state_or_provinces
	{
		get
		{
			return this.GetTable<state_or_province>();
		}
	}
	
	public System.Data.Linq.Table<base_country> base_countries
	{
		get
		{
			return this.GetTable<base_country>();
		}
	}
	
	public System.Data.Linq.Table<ndmh_donation> ndmh_donations
	{
		get
		{
			return this.GetTable<ndmh_donation>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.state_or_province")]
public partial class state_or_province : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _id;
	
	private string _code;
	
	private string _name;
	
	private int _country_id;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OncodeChanging(string value);
    partial void OncodeChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void Oncountry_idChanging(int value);
    partial void Oncountry_idChanged();
    #endregion
	
	public state_or_province()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((this._id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_code", DbType="Char(2) NOT NULL", CanBeNull=false)]
	public string code
	{
		get
		{
			return this._code;
		}
		set
		{
			if ((this._code != value))
			{
				this.OncodeChanging(value);
				this.SendPropertyChanging();
				this._code = value;
				this.SendPropertyChanged("code");
				this.OncodeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(64) NOT NULL", CanBeNull=false)]
	public string name
	{
		get
		{
			return this._name;
		}
		set
		{
			if ((this._name != value))
			{
				this.OnnameChanging(value);
				this.SendPropertyChanging();
				this._name = value;
				this.SendPropertyChanged("name");
				this.OnnameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_country_id", DbType="Int NOT NULL")]
	public int country_id
	{
		get
		{
			return this._country_id;
		}
		set
		{
			if ((this._country_id != value))
			{
				this.Oncountry_idChanging(value);
				this.SendPropertyChanging();
				this._country_id = value;
				this.SendPropertyChanged("country_id");
				this.Oncountry_idChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.base_country")]
public partial class base_country : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _country_id;
	
	private string _iso2;
	
	private string _iso3;
	
	private string _name_en;
	
	private string _name_fr;
	
	private string _name_de;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oncountry_idChanging(int value);
    partial void Oncountry_idChanged();
    partial void Oniso2Changing(string value);
    partial void Oniso2Changed();
    partial void Oniso3Changing(string value);
    partial void Oniso3Changed();
    partial void Onname_enChanging(string value);
    partial void Onname_enChanged();
    partial void Onname_frChanging(string value);
    partial void Onname_frChanged();
    partial void Onname_deChanging(string value);
    partial void Onname_deChanged();
    #endregion
	
	public base_country()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_country_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int country_id
	{
		get
		{
			return this._country_id;
		}
		set
		{
			if ((this._country_id != value))
			{
				this.Oncountry_idChanging(value);
				this.SendPropertyChanging();
				this._country_id = value;
				this.SendPropertyChanged("country_id");
				this.Oncountry_idChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iso2", DbType="Char(2)")]
	public string iso2
	{
		get
		{
			return this._iso2;
		}
		set
		{
			if ((this._iso2 != value))
			{
				this.Oniso2Changing(value);
				this.SendPropertyChanging();
				this._iso2 = value;
				this.SendPropertyChanged("iso2");
				this.Oniso2Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iso3", DbType="Char(3)")]
	public string iso3
	{
		get
		{
			return this._iso3;
		}
		set
		{
			if ((this._iso3 != value))
			{
				this.Oniso3Changing(value);
				this.SendPropertyChanging();
				this._iso3 = value;
				this.SendPropertyChanged("iso3");
				this.Oniso3Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name_en", DbType="VarChar(64)")]
	public string name_en
	{
		get
		{
			return this._name_en;
		}
		set
		{
			if ((this._name_en != value))
			{
				this.Onname_enChanging(value);
				this.SendPropertyChanging();
				this._name_en = value;
				this.SendPropertyChanged("name_en");
				this.Onname_enChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name_fr", DbType="VarChar(64)")]
	public string name_fr
	{
		get
		{
			return this._name_fr;
		}
		set
		{
			if ((this._name_fr != value))
			{
				this.Onname_frChanging(value);
				this.SendPropertyChanging();
				this._name_fr = value;
				this.SendPropertyChanged("name_fr");
				this.Onname_frChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name_de", DbType="VarChar(64)")]
	public string name_de
	{
		get
		{
			return this._name_de;
		}
		set
		{
			if ((this._name_de != value))
			{
				this.Onname_deChanging(value);
				this.SendPropertyChanging();
				this._name_de = value;
				this.SendPropertyChanged("name_de");
				this.Onname_deChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ndmh_donations")]
public partial class ndmh_donation : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _d_id;
	
	private string _d_title;
	
	private string _d_fname;
	
	private string _d_lname;
	
	private string _d_in_memory_of;
	
	private decimal _d_amount;
	
	private string _d_credit_type;
	
	private string _d_credit_number;
	
	private string _d_credit_expiry;
	
	private System.Nullable<System.DateTime> _d_date;
	
	private string _d_comments;
	
	private System.Nullable<int> _dl_id;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ond_idChanging(int value);
    partial void Ond_idChanged();
    partial void Ond_titleChanging(string value);
    partial void Ond_titleChanged();
    partial void Ond_fnameChanging(string value);
    partial void Ond_fnameChanged();
    partial void Ond_lnameChanging(string value);
    partial void Ond_lnameChanged();
    partial void Ond_in_memory_ofChanging(string value);
    partial void Ond_in_memory_ofChanged();
    partial void Ond_amountChanging(decimal value);
    partial void Ond_amountChanged();
    partial void Ond_credit_typeChanging(string value);
    partial void Ond_credit_typeChanged();
    partial void Ond_credit_numberChanging(string value);
    partial void Ond_credit_numberChanged();
    partial void Ond_credit_expiryChanging(string value);
    partial void Ond_credit_expiryChanged();
    partial void Ond_dateChanging(System.Nullable<System.DateTime> value);
    partial void Ond_dateChanged();
    partial void Ond_commentsChanging(string value);
    partial void Ond_commentsChanged();
    partial void Ondl_idChanging(System.Nullable<int> value);
    partial void Ondl_idChanged();
    #endregion
	
	public ndmh_donation()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int d_id
	{
		get
		{
			return this._d_id;
		}
		set
		{
			if ((this._d_id != value))
			{
				this.Ond_idChanging(value);
				this.SendPropertyChanging();
				this._d_id = value;
				this.SendPropertyChanged("d_id");
				this.Ond_idChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_title", DbType="VarChar(50)")]
	public string d_title
	{
		get
		{
			return this._d_title;
		}
		set
		{
			if ((this._d_title != value))
			{
				this.Ond_titleChanging(value);
				this.SendPropertyChanging();
				this._d_title = value;
				this.SendPropertyChanged("d_title");
				this.Ond_titleChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_fname", DbType="VarChar(50)")]
	public string d_fname
	{
		get
		{
			return this._d_fname;
		}
		set
		{
			if ((this._d_fname != value))
			{
				this.Ond_fnameChanging(value);
				this.SendPropertyChanging();
				this._d_fname = value;
				this.SendPropertyChanged("d_fname");
				this.Ond_fnameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_lname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string d_lname
	{
		get
		{
			return this._d_lname;
		}
		set
		{
			if ((this._d_lname != value))
			{
				this.Ond_lnameChanging(value);
				this.SendPropertyChanging();
				this._d_lname = value;
				this.SendPropertyChanged("d_lname");
				this.Ond_lnameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_in_memory_of", DbType="VarChar(50)")]
	public string d_in_memory_of
	{
		get
		{
			return this._d_in_memory_of;
		}
		set
		{
			if ((this._d_in_memory_of != value))
			{
				this.Ond_in_memory_ofChanging(value);
				this.SendPropertyChanging();
				this._d_in_memory_of = value;
				this.SendPropertyChanged("d_in_memory_of");
				this.Ond_in_memory_ofChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_amount", DbType="Decimal(18,2) NOT NULL")]
	public decimal d_amount
	{
		get
		{
			return this._d_amount;
		}
		set
		{
			if ((this._d_amount != value))
			{
				this.Ond_amountChanging(value);
				this.SendPropertyChanging();
				this._d_amount = value;
				this.SendPropertyChanged("d_amount");
				this.Ond_amountChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_credit_type", DbType="VarChar(50)")]
	public string d_credit_type
	{
		get
		{
			return this._d_credit_type;
		}
		set
		{
			if ((this._d_credit_type != value))
			{
				this.Ond_credit_typeChanging(value);
				this.SendPropertyChanging();
				this._d_credit_type = value;
				this.SendPropertyChanged("d_credit_type");
				this.Ond_credit_typeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_credit_number", DbType="Char(16)")]
	public string d_credit_number
	{
		get
		{
			return this._d_credit_number;
		}
		set
		{
			if ((this._d_credit_number != value))
			{
				this.Ond_credit_numberChanging(value);
				this.SendPropertyChanging();
				this._d_credit_number = value;
				this.SendPropertyChanged("d_credit_number");
				this.Ond_credit_numberChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_credit_expiry", DbType="VarChar(50)")]
	public string d_credit_expiry
	{
		get
		{
			return this._d_credit_expiry;
		}
		set
		{
			if ((this._d_credit_expiry != value))
			{
				this.Ond_credit_expiryChanging(value);
				this.SendPropertyChanging();
				this._d_credit_expiry = value;
				this.SendPropertyChanged("d_credit_expiry");
				this.Ond_credit_expiryChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_date", DbType="Date")]
	public System.Nullable<System.DateTime> d_date
	{
		get
		{
			return this._d_date;
		}
		set
		{
			if ((this._d_date != value))
			{
				this.Ond_dateChanging(value);
				this.SendPropertyChanging();
				this._d_date = value;
				this.SendPropertyChanged("d_date");
				this.Ond_dateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_d_comments", DbType="VarChar(50)")]
	public string d_comments
	{
		get
		{
			return this._d_comments;
		}
		set
		{
			if ((this._d_comments != value))
			{
				this.Ond_commentsChanging(value);
				this.SendPropertyChanging();
				this._d_comments = value;
				this.SendPropertyChanged("d_comments");
				this.Ond_commentsChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dl_id", DbType="Int")]
	public System.Nullable<int> dl_id
	{
		get
		{
			return this._dl_id;
		}
		set
		{
			if ((this._dl_id != value))
			{
				this.Ondl_idChanging(value);
				this.SendPropertyChanging();
				this._dl_id = value;
				this.SendPropertyChanged("dl_id");
				this.Ondl_idChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591