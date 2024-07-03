using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactPage : ContentPage
{
    private Contact? contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    public string ContactId
    {
        set
        {
           contact = ContactRepository.GetContactById(int.Parse(value));
           entryName.Text = contact?.Name;
           entryEmail.Text = contact?.Email;
           entryPhone.Text = contact?.Phone;
           entryAddress.Text = contact?.Address;

        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        //Creating this contact object for the null checks
        Contact? contact1 = new()
        { 
            Name = entryName.Text,
            Email = entryEmail.Text,
            Phone = entryPhone.Text,
            Address = entryAddress.Text,
        };

        contact = contact1;

        ContactRepository.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }
}