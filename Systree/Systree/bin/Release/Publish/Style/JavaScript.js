// JavaScript

/** Alerts **/
var close = document.getElementsByClassName("closebtn");
var i;

for (i = 0; i < close.length; i++) {
    close[i].onclick = function () {
        var div = this.parentElement;
        div.style.opacity = "0";
        setTimeout(function () { div.style.display = "none"; }, 500);
    }
}

/** Tips **/
var tips = [
    "Una de las más comunes causas de muerte de las plantas es el exceso de riego. Entonces, es importante que estés informado acerca de cuál es la cantidad de agua que necesita el tipo de planta que tienes, y cada cuánto tiempo es necesario regarla. ",

    "Cuando estés de vacaciones no te olvides de tus plantas. Para sobrevivir, además de agua, las plantas necesitan luz y calor.Asegúrate de dejarlas con alguien que las pueda cuidar, o de tener algunas precauciones para que no le falte lo que precisan.",

    "Evita comer cerca de las plantas. Es importante que los restos de comida o bebida no estén cerca de las plantas, ya que moscas y otros visitantes indeseados podrían ocupar tus plantas y arruinarlas.",

    "Cada cierto tiempo, también es necesario que lo averigues dependiendo de la planta que tengas, debes podar las plantas. Esto es importante porque no solamente se ven mejor estéticamente, sino que se vuelven más sanas.",

    "Coloca las plantas en un lugar donde puedan recibir luz solar y calor, también aire y sombra dependiedo del tipo de planta que sea.Pero trata de no moverlas con frecuencia, ya que puede que no se adapten fácilmente al ser cambiadas de orientación.",

    "Para un buen cuidado de las plantas es necesario sacar el polvo, limpiarlas para mantener lejos los parásitos y permitir que respiren.",

    "Fertilizar es muy importante para el cuidado de las plantas. Debemos aportar vitaminas y minerales como el «hierro, magnesio, boro y zinc» aunque siempre en función de cada tipo de planta.",

    "Los insectos como las hormigas, pueden ser mortales para el cuidado de las plantas. Una buena idea es colocar hierbas aromáticas como jazmín u orégano.",

    "Cada planta necesita unas condiciones de luz, agua y temperatura diferentes. Hay que informarse y preguntar antes sobre el adecuado cuidado de las plantas.",

    "El trasplante a una maceta mayor se hará inevitable con el crecimiento de la planta. Excepto en algunas especies, como la por ejemplo la orquídea, no es bueno que las raíces se encuentren apretadas: tienden a enrollarse, al buscar cómo crecer, y acaban por ocupar todo el espacio, quedándose sin aire.",

    "Ten cuidado con tus mascotas. Algunos animales, sobre todo los gatos, tienen una especial fijación por mordisquear las hojas o comérselas para purgarse, o incluso rascar la tierra.",

    "Lleva una agenda de tus plantas: Busca información sobre la planta que tienes y apúntate cuál es su periodo de floración, de abono y, en caso de necesitarlo, de poda.",

    "Tener las macetas y plantas limpias y libres de hojas y flores muertas. Si aparecen malas hierbas quitárselas lo antes posible para que todos los nutrientes de la tierra sólo los absorba nuestra planta."
]

function suggestATip() {
    var x = Math.floor((Math.random() * tips.length));
    document.getElementById("tipText").innerHTML = tips[x];
    $("#myModal").modal();
}

function tip() {
    var tipsTable = document.getElementById("tipsTable");
    for (i = 0; i < tips.length; i++) {
        var htmlRow = "<tr><td>" + (i + 1) + "</td><td>" + tips[i] + "</td></tr>";
        tipsTable.innerHTML += htmlRow;
    }
}