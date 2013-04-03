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
public partial class faqsDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void Insertndmh_faq(ndmh_faq instance);
  partial void Updatendmh_faq(ndmh_faq instance);
  partial void Deletendmh_faq(ndmh_faq instance);
  partial void Insertndmh_faq_keyword(ndmh_faq_keyword instance);
  partial void Updatendmh_faq_keyword(ndmh_faq_keyword instance);
  partial void Deletendmh_faq_keyword(ndmh_faq_keyword instance);
  #endregion
	
	public faqsDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["cvoorberConnectionString1"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public faqsDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public faqsDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public faqsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public faqsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<ndmh_faq> ndmh_faqs
	{
		get
		{
			return this.GetTable<ndmh_faq>();
		}
	}
	
	public System.Data.Linq.Table<ndmh_faq_keyword> ndmh_faq_keywords
	{
		get
		{
			return this.GetTable<ndmh_faq_keyword>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ndmh_faqs")]
public partial class ndmh_faq : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ndmh_faq_id;
	
	private string _ndmh_faq_title;
	
	private EntitySet<ndmh_faq_keyword> _ndmh_faq_keywords;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onndmh_faq_idChanging(int value);
    partial void Onndmh_faq_idChanged();
    partial void Onndmh_faq_titleChanging(string value);
    partial void Onndmh_faq_titleChanged();
    #endregion
	
	public ndmh_faq()
	{
		this._ndmh_faq_keywords = new EntitySet<ndmh_faq_keyword>(new Action<ndmh_faq_keyword>(this.attach_ndmh_faq_keywords), new Action<ndmh_faq_keyword>(this.detach_ndmh_faq_keywords));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ndmh_faq_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int ndmh_faq_id
	{
		get
		{
			return this._ndmh_faq_id;
		}
		set
		{
			if ((this._ndmh_faq_id != value))
			{
				this.Onndmh_faq_idChanging(value);
				this.SendPropertyChanging();
				this._ndmh_faq_id = value;
				this.SendPropertyChanged("ndmh_faq_id");
				this.Onndmh_faq_idChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ndmh_faq_title", DbType="VarChar(1000)")]
	public string ndmh_faq_title
	{
		get
		{
			return this._ndmh_faq_title;
		}
		set
		{
			if ((this._ndmh_faq_title != value))
			{
				this.Onndmh_faq_titleChanging(value);
				this.SendPropertyChanging();
				this._ndmh_faq_title = value;
				this.SendPropertyChanged("ndmh_faq_title");
				this.Onndmh_faq_titleChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ndmh_faq_ndmh_faq_keyword", Storage="_ndmh_faq_keywords", ThisKey="ndmh_faq_id", OtherKey="ndmh_faq_id")]
	public EntitySet<ndmh_faq_keyword> ndmh_faq_keywords
	{
		get
		{
			return this._ndmh_faq_keywords;
		}
		set
		{
			this._ndmh_faq_keywords.Assign(value);
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
	
	private void attach_ndmh_faq_keywords(ndmh_faq_keyword entity)
	{
		this.SendPropertyChanging();
		entity.ndmh_faq = this;
	}
	
	private void detach_ndmh_faq_keywords(ndmh_faq_keyword entity)
	{
		this.SendPropertyChanging();
		entity.ndmh_faq = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ndmh_faq_keywords")]
public partial class ndmh_faq_keyword : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _fkword_id;
	
	private string _faq_keyword;
	
	private int _ndmh_faq_id;
	
	private string _associated_faq_name;
	
	private EntityRef<ndmh_faq> _ndmh_faq;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onfkword_idChanging(int value);
    partial void Onfkword_idChanged();
    partial void Onfaq_keywordChanging(string value);
    partial void Onfaq_keywordChanged();
    partial void Onndmh_faq_idChanging(int value);
    partial void Onndmh_faq_idChanged();
    partial void Onassociated_faq_nameChanging(string value);
    partial void Onassociated_faq_nameChanged();
    #endregion
	
	public ndmh_faq_keyword()
	{
		this._ndmh_faq = default(EntityRef<ndmh_faq>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fkword_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int fkword_id
	{
		get
		{
			return this._fkword_id;
		}
		set
		{
			if ((this._fkword_id != value))
			{
				this.Onfkword_idChanging(value);
				this.SendPropertyChanging();
				this._fkword_id = value;
				this.SendPropertyChanged("fkword_id");
				this.Onfkword_idChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_faq_keyword", DbType="VarChar(1000) NOT NULL", CanBeNull=false)]
	public string faq_keyword
	{
		get
		{
			return this._faq_keyword;
		}
		set
		{
			if ((this._faq_keyword != value))
			{
				this.Onfaq_keywordChanging(value);
				this.SendPropertyChanging();
				this._faq_keyword = value;
				this.SendPropertyChanged("faq_keyword");
				this.Onfaq_keywordChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ndmh_faq_id", DbType="Int NOT NULL")]
	public int ndmh_faq_id
	{
		get
		{
			return this._ndmh_faq_id;
		}
		set
		{
			if ((this._ndmh_faq_id != value))
			{
				if (this._ndmh_faq.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.Onndmh_faq_idChanging(value);
				this.SendPropertyChanging();
				this._ndmh_faq_id = value;
				this.SendPropertyChanged("ndmh_faq_id");
				this.Onndmh_faq_idChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_associated_faq_name", DbType="VarChar(1000)")]
	public string associated_faq_name
	{
		get
		{
			return this._associated_faq_name;
		}
		set
		{
			if ((this._associated_faq_name != value))
			{
				this.Onassociated_faq_nameChanging(value);
				this.SendPropertyChanging();
				this._associated_faq_name = value;
				this.SendPropertyChanged("associated_faq_name");
				this.Onassociated_faq_nameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ndmh_faq_ndmh_faq_keyword", Storage="_ndmh_faq", ThisKey="ndmh_faq_id", OtherKey="ndmh_faq_id", IsForeignKey=true)]
	public ndmh_faq ndmh_faq
	{
		get
		{
			return this._ndmh_faq.Entity;
		}
		set
		{
			ndmh_faq previousValue = this._ndmh_faq.Entity;
			if (((previousValue != value) 
						|| (this._ndmh_faq.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._ndmh_faq.Entity = null;
					previousValue.ndmh_faq_keywords.Remove(this);
				}
				this._ndmh_faq.Entity = value;
				if ((value != null))
				{
					value.ndmh_faq_keywords.Add(this);
					this._ndmh_faq_id = value.ndmh_faq_id;
				}
				else
				{
					this._ndmh_faq_id = default(int);
				}
				this.SendPropertyChanged("ndmh_faq");
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