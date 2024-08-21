<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Menu.Master" AutoEventWireup="true" CodeBehind="RegistrarViajero.aspx.cs" Inherits="WebApp.CapaPresentacion.RegistroViajeros.RegistrarViajero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">}
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.7.1/css/buttons.dataTables.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.1/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.2.2/jszip.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.1/js/buttons.html5.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="app-content-header">
      <br />
      <br />
      <br />
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-6">
                    <h3 class="mb-0">Registro de Viajeros</h3>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-end">
                        <li class="breadcrumb-item"><a href="/Default.aspx">Home</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Registro de Viajeros</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>

    <div class="card">
        <div class="card-body">
            <div style="margin-left: 15px;">
                <div class="row">
                    <div class="col-12">
                        <asp:LinkButton runat="server" ID="btnNuevo" OnClick="btnNuevo_Click" CssClass="btn btn-success">
                            <i class="bi bi-plus-lg"></i> Nuevo Viajero
                        </asp:LinkButton>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-11">
                        <asp:GridView ID="gvViajeros" CssClass="table table-bordered dataTables1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="IDViajero" HeaderText="ID de Viajero" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="NroPasaporte" HeaderText="Número de Pasaporte" />
                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <div class="d-flex justify-content-center">
                                            <asp:LinkButton runat="server" CssClass="btn btn-sm btn-primary"
                                                CommandArgument='<%# Eval("IDViajero") %>'>
                                                <i class="bi bi-pencil-square"></i> Editar
                                            </asp:LinkButton>&nbsp;
                                            <asp:LinkButton runat="server" OnClick="btnEliminar_Click" CssClass="btn btn-sm btn-danger"
                                                OnClientClick="return confirm('¿Deseas eliminar al viajero?')"
                                                CommandArgument='<%# Eval("IDViajero") %>'>
                                                <i class="bi bi-trash3"></i> Eliminar
                                            </asp:LinkButton>&nbsp;
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
