<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
     <div class="home-content">
        <div class="home-top">
            <ul>
                <li>
                    <img class="myImages w3-animate-opacity" src="Content/img/sistemas_1.jpg" />
                    <div class="footer-carrera w3-animate-fading">Ingeniera en Sistemas</div>
                </li>
                <li>
                    <img class="myImages w3-animate-opacity"  src="Content/img/mecanica_01_1.jpg" />
                    <div class="footer-carrera w3-animate-fading">Ingeniera Mecanica</div>
                </li>
                <li>
                    <img class="myImages w3-animate-opacity" src="Content/img/quimica_1.jpg" />
                    <div class="footer-carrera w3-animate-fading">Ingeniera Quimica</div>
                </li>
                <li>
                    <img class="myImages w3-animate-opacity" src="Content/img/electricista_1.jpg" />
                    <div class="footer-carrera w3-animate-fading">Ingeniera Electrica</div>
                </li>
            </ul>
        </div>
        <div class="home-middle">
            <div class="left">
                <div class="card">
                    <b>Jornada: Jóvenes que transforman Santa Fe</b>
                    <p>El día jueves 4 de noviembre, a las 18, se llevará adelante la jornada “Jóvenes que transforman Santa Fe”.</p>
                    <p>Esta consiste de un espacio para conectar talento joven, visibilizar experiencias de alto  ...</p>
                </div>
                <div class="card">
                    <b>Jornada: Jóvenes que transforman Santa Fe</b>
                    <p>El día jueves 4 de noviembre, a las 18, se llevará adelante la jornada “Jóvenes que transforman Santa Fe”.</p>
                    <p>Esta consiste de un espacio para conectar talento joven, visibilizar experiencias de alto  ...</p>
                </div>
                <div class="card">
                    <b>Jornada: Jóvenes que transforman Santa Fe</b>
                    <p>El día jueves 4 de noviembre, a las 18, se llevará adelante la jornada “Jóvenes que transforman Santa Fe”.</p>
                    <p>Esta consiste de un espacio para conectar talento joven, visibilizar experiencias de alto  ...</p>
                </div>
                <div class="card">
                    <b>Jornada: Jóvenes que transforman Santa Fe</b>
                    <p>El día jueves 4 de noviembre, a las 18, se llevará adelante la jornada “Jóvenes que transforman Santa Fe”.</p>
                    <p>Esta consiste de un espacio para conectar talento joven, visibilizar experiencias de alto  ...</p>
                </div>
                <div class="card">
                    <b>Jornada: Jóvenes que transforman Santa Fe</b>
                    <p>El día jueves 4 de noviembre, a las 18, se llevará adelante la jornada “Jóvenes que transforman Santa Fe”.</p>
                    <p>Esta consiste de un espacio para conectar talento joven, visibilizar experiencias de alto  ...</p>
                </div>
                <div class="card">
                    <b>Jornada: Jóvenes que transforman Santa Fe</b>
                    <p>El día jueves 4 de noviembre, a las 18, se llevará adelante la jornada “Jóvenes que transforman Santa Fe”.</p>
                    <p>Esta consiste de un espacio para conectar talento joven, visibilizar experiencias de alto  ...</p>
                </div>
            </div>
        
            <div class="rigth">
                <img src="Content/img/idiomas1.jpg" />
                <img src="Content/img/bannercovid19.png" />
                <img src="Content/img/turnos-Online-Frro.png" />
                <img src="Content/img/ventanilla-zoom-utn-frro.jpeg" />
            </div>
        </div>
         <script>
             var slideIndex = 0;
             var array = ["Ingenieria en Sistemas", "Ingenieria Mecanica", "Ingenieria Quimica", "Ingenieria Electrica"]
             carousel();

             function carousel() {

                 var i;
                 var x = document.getElementsByClassName("myImages");
                 var y = document.getElementsByClassName("footer-carrera")
                 for (i = 0; i < x.length; i++) {
                     x[i].style.display = "none";
                     y[i].style.display = "none";
                 }
                 slideIndex++;
                 if (slideIndex > x.length) { slideIndex = 1 }
                 x[slideIndex - 1].style.display = "block";
                 y[slideIndex - 1].style.display = "block";
                 setTimeout(carousel, 5000);
             }
         </script>
    </div>
</asp:Content>
