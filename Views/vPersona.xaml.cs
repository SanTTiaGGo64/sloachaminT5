using sloachaminT5.Models;

namespace sloachaminT5.Views;

public partial class vPersona : ContentPage
{
    public vPersona()
    {
        InitializeComponent();
    }
    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.AddNewPerson(txtName.Text);
        lblStatus.Text = App.personRepo.StatusMessage;
        btnObtener_Clicked(sender, e);
    }
    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people = App.personRepo.getAllPeople();
        listaPersona.ItemsSource = people;
        lblStatus.Text = App.personRepo.StatusMessage;
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Grid grid = (Grid)button.Parent;
        Entry idEntry = (Entry)grid.Children[0];
        int id = Convert.ToInt32(idEntry.Text);

        lblStatus.Text = "";
        App.personRepo.DeletePerson(id);
        lblStatus.Text = App.personRepo.StatusMessage;
        btnObtener_Clicked(sender, e);
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Grid grid = (Grid)button.Parent;
        Entry idEntry = (Entry)grid.Children[0];
        Entry nameEntry = (Entry)grid.Children[1];
        int id = Convert.ToInt32(idEntry.Text); 
        string name = nameEntry.Text;

        lblStatus.Text = "";
        App.personRepo.UpdatePersonName(id, name);
        lblStatus.Text = App.personRepo.StatusMessage;
        btnObtener_Clicked(sender, e);
    }
}