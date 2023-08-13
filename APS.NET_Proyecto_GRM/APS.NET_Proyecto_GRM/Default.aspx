<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="APS.NET_Proyecto_GRM._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="row">
            <div class="card text-bg-dark">
                <img src="/Recursos/wp-1.jpg" class="card-img" alt="...">
                <div class="card-img-overlay text-center">
                    <h1 class="card-title">Creación de DVDs</h1>
                    <p class="card-text">Esta plataforma permite crear DVDs a partir de películas que existen o en su caso, dar de alta una película.</p>
                    <p><a href="/Catalogos/Dvds/ListarDvds.aspx" class="btn btn-primary btn-md">Lista DVDs</a></p>
                </div>
            </div>
        </div>

        <br />

        <section class="row">
            <article>
                <h3> Reglas de negocio y usuario </h3> <br />

                <h5>DVDs</h5>
                <ul>
                    <li>Los DVDs son creados a partir de una película, lenguaje (doblaje) y audio.</li>
                    <li>Agregar --> No se pueden crear dvd con el mismo Isbn y los campos nombre de película, lenguaje, formato de audio, isbn y fecha de lanzamiento no pueden quedar vacíos.</li>
                    <li>Editar ----> Solo se podrán editar los campos edición, formato de pantalla, regió   n e imagen(portada).</li>   
                    <li>Eliminar -> Todo se puede eliminar (aquí la lógica de negocio no aplica).</li>
                </ul>

                <h5>Lenguajes</h5>
                <ul>
                    <li>El lenguaje de los DVD es en realidad el Doblaje del cual se creó el DVD para su distribución.</li>
                    <li>Agregar --> No se pueden agregar lenguajes con el mismo nombre (excepto si lleva acentos) y no vacíos.</li>
                    <li>Editar ----> No vacíos.</li>
                    <li>Eliminar -> No se puede eliminar el lenguaje si lo posee uno o varios DVDs.</li>
                </ul>

                <h5>Audios</h5>
                <ul>
                    <li>El audio es el formato con el que se crean los DVDs.</li>
                    <li>Agregar --> No se pueden agregar formatos de audios con el mismo nombre (excepto si lleva acentos) y no vacíos.</li>
                    <li>Editar ----> No vacíos.</li>
                    <li>Eliminar -> No se puede eliminar el audio si lo posee uno o varios DVDs.</li>
                </ul>

                <h5>Películas</h5>
                <ul>
                    <li>La puntuación es la calificación que se le da a la película en determinada plataforma.</li>
                    <li>Agregar --> No se pueden agregar películas con el mismo nombre (excepto si lleva acentos) y no vacíos.</li>
                    <li>Editar ----> No vacíos, campos nombre, fecha de lanzamiento y Imdb no se pueden cambiar.</li>
                    <li>Eliminar -> No se puede eliminar una película si posee una o varias puntuaciones y este presente en uno o varios DVDs.</li>
                </ul>

                <h5>Puntuaciones</h5>
                <ul>
                    <li>La puntuación es la calificación que se le da a la película en determinada plataforma.</li>
                    <li>Agregar --> No vacíos, no pueden tener la misma película y nombre de plataforma, y puntuación debe estar entre el rango de 1 a 10 (se aceptan decimales).</li>
                    <li>Editar ----> No vacíos, campo película ya no se cambia y puntuación debe estar entre el rango de 1 a 10 (se aceptan decimales).</li>
                    <li>Eliminar -> Todo se puede eliminar (aquí la lógica de negocio no aplica).</li>
                </ul>

                <h5>Géneros</h5>
                <ul>
                    <li>El género le pertenece a la película.</li>
                    <li>Agregar --> No se pueden agregar géneros con el mismo nombre (excepto si lleva acentos) y no vacíos.</li>
                    <li>Editar ----> No vacíos.</li>
                    <li>Eliminar -> No se puede eliminar el género si lo posee una o varias películas.</li>
                </ul>

            </article>
        </section>
    </main>

</asp:Content>
