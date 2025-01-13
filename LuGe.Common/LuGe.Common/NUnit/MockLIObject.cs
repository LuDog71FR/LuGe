/*
 * User: Ludovic Germain
 * Date: 11/07/2007
 * Time: 14:53
 */

using System;
using LuGe.Common;
using LuGe.Common.Collection;
using System.Resources;

namespace LuGe.Common.Tests
{
	/// <summary>
	/// Mock object of LIObject class.
	/// </summary>
	public class MockLIObject: LIObject, IKeyedItem, IComparable<MockLIObject>
	{
		#region Fields
		
		private string _adress;
		private int _phone;
		private string _internalField;
		
		#endregion
		
		#region Constructors
		
		public MockLIObject(): base(){
			this.InternalField = "internal";
		}
		
		public MockLIObject(string adress,
		                    int phone): this(){
			this.Adress = adress;
			this.Phone = phone;
		}
		
		#endregion
		
		#region Properties
		
		public string Key {
			get { return String.Concat(this.Adress, this.Phone.ToString()); }
		}
		
		public ResourceManager MockResources {
			get { return base.Resources; }
		}
		
		public string Adress {
			get { return _adress; }
			set { _adress = value; }
		}
		
		public int Phone {
			get { return _phone; }
			set { _phone = value; }
		}
		
		public string PublicInternalField {
			get { return _internalField; }
		}
		
		private string InternalField {
			get { return _internalField; }
			set { _internalField = value; }
		}
		
		#endregion
		
		#region Methods
		
        private bool GetAdressByRef(ref string adress)
        {
            adress = Adress;
            return true;
        }

        private bool GetAdressByOut(out string adress)
        {
            adress = Adress;
            return true;
        }

		public void MockSetError() {
			this.SetError(this.Resources.GetString("Error : Phone = 0"));
		}
		
		public void MockClearError() {
			this.ClearError();
		}
		
		private void ChangeInternalField() {
			this.InternalField = "changed";
		}
		
		private bool ChangeAdressAndPhone(string adress, int phone) {
			this.Adress = adress;
			this.Phone = phone;
			
			return true;
		}
		
        private static bool IsTrue() {
        	return true;
        }
        
        private static string GetAdress()
        {
        	return "My adress";
        }
        
		public override string ToString()
		{
			return Adress;
		}
		
		public int CompareTo(MockLIObject obj)
		{
			if (obj == null) throw new ArgumentNullException("obj");
			
			return this.Phone.CompareTo(obj.Phone);
		}
		
		#endregion
	}
}
