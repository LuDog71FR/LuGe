/*
 * User: lgermain
 * Date: 03/06/2008 11:11
 */

using System;
using LuGe.Common.Collection;

namespace LuGe.Common.Tests
{
	/// <summary>
	/// Description of MockLIObjectBis.
	/// </summary>
	public class MockLIObjectBis : IKeyedItem
	{
		#region Fields
		
		private string _adress;
		private int _phone;
		
		#endregion
		
		#region Constructors
		
		public MockLIObjectBis(): base(){}
		
		public MockLIObjectBis(string adress,
		                    int phone): this(){
			this.Adress = adress;
			this.Phone = phone;
		}
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		public string Key {
			get { return String.Concat(this.Adress, this.Phone.ToString()); }
		}
		
		public string Adress {
			get { return _adress; }
			set { _adress = value; }
		}
		
		public int Phone {
			get { return _phone; }
			set { _phone = value; }
		}
		
		#endregion
	}
}
