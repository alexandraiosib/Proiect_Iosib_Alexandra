using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AprozarModel;
using System.Data.Entity;
using System.Data;



namespace Proiect_Iosib_Alexandra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        AprozarEntitiesModel ctx = new AprozarEntitiesModel();
        CollectionViewSource clientiVSource;
        CollectionViewSource furnizoriVSource;
        CollectionViewSource produseVSource;
        CollectionViewSource clientiComenziClientiVSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource produseViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("produseViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // produseViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource clientiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clientiViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource furnizoriViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("furnizoriViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // furnizoriViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource comenziClientiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("comenziClientiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // comenziClientiViewSource.Source = [generic data source]
            clientiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiViewSource")));
            clientiVSource.Source = ctx.Clientis.Local;
            ctx.Clientis.Load();

            produseVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("produseViewSource")));
            produseVSource.Source = ctx.Produses.Local;
            ctx.Produses.Load();

            furnizoriVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("furnizoriViewSource")));
            furnizoriVSource.Source = ctx.Furnizoris.Local;
            ctx.Furnizoris.Load();

            clientiComenziClientiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiComenziClientiViewSource")));
            //clientiComenziClientiVSource.Source = ctx.ComenziClientis.Local;
            ctx.ComenziClientis.Load();

            //cmbClienti.DisplayMemberPath = "Nume";
            cmbClienti.SelectedValuePath = "ClientId";

            //cmbProduse.DisplayMemberPath = "Denumire";
            cmbProduse.SelectedValuePath = "ProdusId";

            BindDataGrid();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }

        private void btnPrevious_Clienti_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToPrevious();
        }

        private void btnNext_Clienti_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToNext();
        }

        private void SaveClienti()
        {
            Clienti clienti = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    clienti = new Clienti()
                    {
                        Prenume = prenumeTextBox.Text.Trim(),
                        Nume = numeTextBox.Text.Trim(),
                        AdresaEmail = adresaEmailTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Clientis.Add(clienti);
                    clientiVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            if (action == ActionState.Edit)
            {
                try
                {
                    clienti = (Clienti)clientiDataGrid.SelectedItem;
                    clienti.Prenume = prenumeTextBox.Text.Trim();
                    clienti.Nume = numeTextBox.Text.Trim();
                    clienti.AdresaEmail = adresaEmailTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    clienti = (Clienti)clientiDataGrid.SelectedItem;
                    ctx.Clientis.Remove(clienti);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clientiVSource.View.Refresh();
            }
        }

        private void btnNext_Prod_Click(object sender, RoutedEventArgs e)
        {
            produseVSource.View.MoveCurrentToNext();
        }

        private void btnPrevious_Prod_Click(object sender, RoutedEventArgs e)
        {
            produseVSource.View.MoveCurrentToPrevious();
        }

        private void SaveProduse()
        {
            Produse produse = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Produse entity
                    produse = new Produse()
                    {
                        Denumire = denumireTextBox.Text.Trim(),
                        Pret = pretTextBox.Text.Trim(),
                        TaraOrigine = taraOrigineTextBox.Text.Trim(),


                    };
                    //adaugam entitatea nou creata in context
                    ctx.Produses.Add(produse);
                    produseVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            if (action == ActionState.Edit)
            {
                try
                {
                    produse = (Produse)produseDataGrid.SelectedItem;
                    produse.Denumire = denumireTextBox.Text.Trim();
                    produse.Pret = pretTextBox.Text.Trim();
                    produse.TaraOrigine = taraOrigineTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    produse = (Produse)produseDataGrid.SelectedItem;
                    ctx.Produses.Remove(produse);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                produseVSource.View.Refresh();
            }
        }



        private void btnPrevious_Furnizori_Click(object sender, RoutedEventArgs e)
        {
            furnizoriVSource.View.MoveCurrentToPrevious();
        }

        private void btnNext_Furnizori_Click(object sender, RoutedEventArgs e)
        {
            furnizoriVSource.View.MoveCurrentToNext();
        }

        private void SaveFurnizori()
        {
            Furnizori furnizori = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Produse entity
                    furnizori = new Furnizori()
                    {
                        Nume = numeTextBox.Text.Trim(),
                        Adresa = adresaTextBox.Text.Trim(),
                        Cantitate = cantitateTextBox.Text.Trim(),

                    };
                    //adaugam entitatea nou creata in context
                    ctx.Furnizoris.Add(furnizori);
                    furnizoriVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            if (action == ActionState.Edit)
            {
                try
                {
                    furnizori = (Furnizori)furnizoriDataGrid.SelectedItem;
                    furnizori.Nume = numeTextBox.Text.Trim();
                    furnizori.Adresa = adresaTextBox.Text.Trim();
                    furnizori.Cantitate = cantitateTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    furnizori = (Furnizori)furnizoriDataGrid.SelectedItem;
                    ctx.Furnizoris.Remove(furnizori);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                furnizoriVSource.View.Refresh();
            }
        }

        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }
        private void ReInitialize()
        {
            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlAprozar.SelectedItem as TabItem;
            switch (ti.Header)
            {
                case "Produse":
                    SaveProduse();
                    break;
                case "Clienti":
                    SaveClienti();
                    break;
                case "Furnizori":
                    SaveFurnizori();
                    break;
                case "ComenziClienti":
                    break;
            }
            ReInitialize();
        }

        private void SaveComenziClienti()
        {
            ComenziClienti comenziclienti = null;
            if (action == ActionState.New)
            {
                try
                {
                    Clienti clienti = (Clienti)cmbClienti.SelectedItem;
                    Produse produse = (Produse)cmbProduse.SelectedItem;
                    //instantiem Order entity
                    comenziclienti = new ComenziClienti()
                    {
                        ClientId = clienti.ClientId,
                        ProdusId = produse.ProdusId
                    };
                    //adaugam entitatea nou creata in context
                    ctx.ComenziClientis.Add(comenziclienti);
                    //salvam modificarile
                    ctx.SaveChanges();
                    BindDataGrid();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (action == ActionState.Edit)
                {
                    dynamic selectedComenziClienti = comenziClientisDataGrid.SelectedItem;
                    try
                    {
                        int curr_id = selectedComenziClienti.ComandaCId;
                        var editedOrder = ctx.ComenziClientis.FirstOrDefault(s => s.ComandaCId == curr_id);
                        if (editedOrder != null)
                        {
                            editedOrder.ClientId = Int32.Parse(cmbClienti.SelectedValue.ToString());
                            editedOrder.ProdusId = Convert.ToInt32(cmbProduse.SelectedValue.ToString());
                            //salvam modificarile
                            ctx.SaveChanges();
                        }
                    }
                    catch (DataException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    BindDataGrid();
                    // pozitionarea pe item-ul curent
                    clientiVSource.View.MoveCurrentTo(selectedComenziClienti);
                }
                else if (action == ActionState.Delete)
                {
                    try
                    {
                        dynamic selectedComenziClienti = comenziClientisDataGrid.SelectedItem;
                        int curr_id = selectedComenziClienti.ComandaCId;
                        var deletedComenziClienti = ctx.ComenziClientis.FirstOrDefault(s => s.ComandaCId == curr_id);
                        if (deletedComenziClienti != null)
                        {
                            ctx.ComenziClientis.Remove(deletedComenziClienti);
                            ctx.SaveChanges();
                            MessageBox.Show("Order Deleted Successfully", "Message");
                            BindDataGrid();
                        }
                    }
                    catch (DataException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void BindDataGrid()
        {
            var queryComenziClienti = from comenzic in ctx.ComenziClientis
                             join client in ctx.Clientis on comenzic.ClientId equals
                             client.ClientId
                             join prod in ctx.Produses on comenzic.ProdusId
                 equals prod.ProdusId
                             select new
                             {
                                 comenzic.ComandaCId,
                                 comenzic.ProdusId,
                                 comenzic.ClientId,
                                 client.Prenume,
                                 client.Nume,
                                 prod.Denumire,
                                 prod.Pret,
                                 prod.TaraOrigine
                             };
            clientiComenziClientiVSource.Source = queryComenziClienti.ToList();
        }
    }
}
