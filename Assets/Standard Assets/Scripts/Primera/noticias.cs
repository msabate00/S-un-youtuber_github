using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class noticias : MonoBehaviour {

    public TextMeshProUGUI texto1;
    public TextMeshProUGUI texto2;

    private int com1;
    private int com2;
    private string not1 = "-Donald Trump acaba con la corrupción al prolongar la tercera guerra mundial: \"Los rusos y americanos ahora vivimos en harmonía\".";
    private string not2 = "-'Cuatro días antes de morir' Los tuiteros reaccionan violentamente contra el 'best seller' por incluir violencia de género masculino.";
    private string not3 = "-La marihuana sufre controles de calidad rigurosos después de inducir el coma en más de 700 casos entre niños de 8 a 10 años.";
    private string not4 = "-Valentino Rossi se muestra furioso ante la prensa y lo manifiesta bañándose en un charco de excrementos mientras grita \"¡Que te jodan papá!\"";
    private string not5 = "-Un niño de Chicago es encerrado en un reformatorio por enseñar a un perro a fumar debido a que según él lo considera 'guay' y rebelde.";
    private string not6 = "-Míster Jägger es sospechoso de reclutar gente para una masacre terrorista, por el momento no se ha demostrado ninguna prueba a favor.";
    private string not7 = "-Jorge Lorenzo : \"Tengo el mismo talento que cuando ganaba Mundiales, lo que ocurre es que el gilipollas de Marquez me truca la moto\".";
    private string not8 = "-Lautaro Martínez: \"Cristiano es mejor que Messi, solo que Cristiano me ha pagado para decir esta gilipollez. ¡Arriba España coño!\".";
    private string not9 = "-Reabren la tumba de Franco después de 70 años y se lo encuentran jugando al 'Minecraft' \"GTFO of my room I'm playing Minecraft!\".";
    private string not10 = "-Feministas de la manifestación '8M' enseñan los pechos a inocentes crios machistas por declararse superior a la raza humana.";
    private string not11 = "-'Los videojuegos hacen a las personas violentas' ahora es una realidad gracias a la ciencia y a la gente ofendida de Twitter.";
    private string not12 = "-El primer paralítico consigue volver a andar gracias a un cliché \" ¿Madre dices?, ¡Nuestra madre es América!\".";
    private string not13 = "-Donald Trump se contradice: \"Yo no soy una persona racista, pero el negro ese de primera fila me está poniendo de mala ostia\".";
    private string not14 = "-'El pan no es ahora más caro, siempre ha sido barato' Nuevos misterios resueltos gracias a los avances tecnológicos en la ciencia.";
    private string not15 = "-Un laboratorio de Màlaga explota por una combustión de metano \"Yo no entendí como fue posible, solamente puse acá esta mierda y explotó sola carajo\".";
    private string not16 = "-Un estudiante estadounidense acribilla a disparos a su profesora por culpa del 'Call Of Duty', ahora los videojuegos son mucho más temibles.";
    private string not17 = "-El cambio climático aumenta en 5ºC la coraza del planeta Tierra.";
    private string not18 = "-El cambio climático es una farsa y ha sido demostrado por la insistencia de Donald Trump a los laboratorios mexicanos.";
    private string not19 = "-Lebron James se muestra ofendido por beber agua \"I only drink 'Gatorade' baby, water is for pussies, yeah nigga motherfucker in the hood\".";
    private string not20 = "-Una nueva temporada de la famosa serie 'House' vendrá encaminada en los próximos meses, así mismo el ratio de suicidio desciende al 0%.";
    private string not21 = "-Fernando Alonso: \"La F1 me odia por ser un viejo de 41 años mientras que a otros comenabos les hacen el pasillo rojo por ser comunistas\"";
    private string not22 = "-El partido político 'Vox' se autoerradica: \"Por favor no me votéis, soy demasiado comunista para vosotros, españoles\"";
    private string not23 = "-Jacob Doetell, el primer elefante transgénico, habla a la prensa: \"Ahora que hablo a ver si tenéis cojones de tirarme cacahuetes hijos de puta\"";
    private string not24 = "-Graban al dueño de un restaurante orinando en la sopa de la competencia";
    private string not25 = "-Una conductora tras volcar en Palma: \"Me lo he pasado de puta madre, como aquella vez en la que asesiné a unos gatos en la calle\".";
    private string not26 = "-Miles de firmas piden que se sutituya la cruz del Valle de los Caídos por una estatua de Batman.";
    private string not27 = "-Parecían apetitosas pero...: Dos alumnos reparten a sus compañeros de colegio galletas hechas con las cenizas de su abuelo.";
    private string not28 = "-Diccionarios Vox admite que le \"le toca las narices\" que exista un partido político con su nombre.";
    private string not29 = "-Ventosidad peligrosa : El pedo de un hipopótamo deja tres hospitalizados";
    private string not30 = "-Dona un riñón a su jefa y la despiden por solicitar una baja médica";
    private string not31 = "-Detenido un ladrón en Florida por dejar su sesión de Facebook abierta en la casa en la que robó";
    private string not32 = "-Ex convicto quiere regresar a prisión para ver gratis los canales premium de TV";
    private string not33 = "-Cancelan un 'reality' sin que nadie avise a los concursantes en 8 meses.";
    private string not34 = "-Un \"no hay cojones\" ha provocado un importante cambio en un pueblo de Chicago: \"Le dije a mi primo que infestara el pueblo de mapaches\".";
    private string not35 = "-Un bar echa a un grupo de curas por creer que se habían disfrazado para una despedida de soltero.";
    private string not36 = "-Cancelan un vuelo en China porque una anciana tiró monedas al motor del avión. Un vuelo de la compañía Lucky Air tuvo que ser cancelado.";
    private string not37 = "-La policía interrumpe una orgía gay con drogas en un piso de El Vaticano. Un sacerdote ha sido detenido, ingresado para desintoxicarse.";
    private string not38 = "-Detienen a un hombre por masturbatse en la calle y eyacular sobre un policía nacional, el arrestado recibió a los agentes cariñosamente.";
    private string not39 = "-Detenido un español por defecar en las ruinas de Pompeya. La policía ha detenido a un anciano de 80 años en la Casa de Menandro.";
    private string not40 = "-Despiden a un funcionario por faltar más de dos mil días al trabajo. \"No sabemos cuál era el problema\".";
    private string not41 = "-Un grupo de niños brasileños apedrea a Papá Noel tras quedarse sin caramelos. \"Comenzaron a correr detrás de nosotros insultándonos\".";
    void OnEnable () {
        int polla = Random.Range(1, 42);
        if (polla == 1)
        {
            texto1.text = not1;
            com1 = polla;
        }
        if (polla == 2)
        {
            texto1.text = not2;
            com1 = polla;
        }
        if (polla == 3)
        {
            texto1.text = not3;
            com1 = polla;
        }
        if (polla == 4)
        {
            texto1.text = not4;
            com1 = polla;
        }
        if (polla == 5)
        {
            texto1.text = not5;
            com1 = polla;
        }
        if (polla == 6)
        {
            texto1.text = not6;
            com1 = polla;
        }
        if (polla == 7)
        {
            texto1.text = not7;
            com1 = polla;
        }
        if (polla == 8)
        {
            texto1.text = not8;
            com1 = polla;
        }
        if (polla == 9)
        {
            texto1.text = not9;
            com1 = polla;
        }
        if (polla == 10)
        {
            texto1.text = not10;
            com1 = polla;
        }
        if (polla == 11)
        {
            texto1.text = not11;
            com1 = polla;
        }
        if (polla == 12)
        {
            texto1.text = not12;
            com1 = polla;
        }
        if (polla == 13)
        {
            texto1.text = not13;
            com1 = polla;
        }
        if (polla == 14)
        {
            texto1.text = not14;
            com1 = polla;
        }
        if (polla == 15)
        {
            texto1.text = not15;
            com1 = polla;
        }
        if (polla == 16)
        {
            texto1.text = not16;
            com1 = polla;
        }
        if (polla == 17)
        {
            texto1.text = not17;
            com1 = polla;
        }
        if (polla == 18)
        {
            texto1.text = not18;
            com1 = polla;
        }
        if (polla == 19)
        {
            texto1.text = not19;
            com1 = polla;
        }
        if (polla == 20)
        {
            texto1.text = not20;
            com1 = polla;
        }
        if (polla == 21)
        {
            texto1.text = not21;
            com1 = polla;
        }
        if (polla == 22)
        {
            texto1.text = not22;
            com1 = polla;
        }
        if (polla == 23)
        {
            texto1.text = not23;
            com1 = polla;
        }
        if (polla == 24)
        {
            texto1.text = not24;
            com1 = polla;
        }
        if (polla == 25)
        {
            texto1.text = not25;
            com1 = polla;
        }
        if (polla == 26)
        {
            texto1.text = not26;
            com1 = polla;
        }
        if (polla == 27)
        {
            texto1.text = not27;
            com1 = polla;
        }
        if (polla == 28)
        {
            texto1.text = not28;
            com1 = polla;
        }
        if (polla == 29)
        {
            texto1.text = not29;
            com1 = polla;
        }
        if (polla == 30)
        {
            texto1.text = not30;
            com1 = polla;
        }
        if (polla == 31)
        {
            texto1.text = not31;
            com1 = polla;
        }
        if (polla == 32)
        {
            texto1.text = not32;
            com1 = polla;
        }
        if (polla == 33)
        {
            texto1.text = not33;
            com1 = polla;
        }
        if (polla == 34)
        {
            texto1.text = not34;
            com1 = polla;
        }
        if (polla == 35)
        {
            texto1.text = not35;
            com1 = polla;
        }
        if (polla == 36)
        {
            texto1.text = not36;
            com1 = polla;
        }
        if (polla == 37)
        {
            texto1.text = not37;
            com1 = polla;
        }
        if (polla == 38)
        {
            texto1.text = not38;
            com1 = polla;
        }
        if (polla == 39)
        {
            texto1.text = not39;
            com1 = polla;
        }
        if (polla == 40)
        {
            texto1.text = not40;
            com1 = polla;
        }
        if (polla == 41)
        {
            texto1.text = not41;
            com1 = polla;
        }






        siguiente();
    }


    void siguiente()
        {
        int polla2 = Random.Range(1, 42);
        if (polla2 == 1)
        {
            texto2.text = not1;
            com2 = polla2;
        }
        if (polla2 == 2)
        {
            texto2.text = not2;
            com2 = polla2;
        }
        if (polla2 == 3)
        {
            texto2.text = not3;
            com2 = polla2;
        }
        if (polla2 == 4)
        {
            texto2.text = not4;
            com2 = polla2;
        }
        if (polla2 == 5)
        {
            texto2.text = not5;
            com2 = polla2;
        }
        if (polla2 == 6)
        {
            texto2.text = not6;
            com2 = polla2;
        }
        if (polla2 == 7)
        {
            texto2.text = not7;
            com2 = polla2;
        }
        if (polla2 == 8)
        {
            texto2.text = not8;
            com2 = polla2;
        }
        if (polla2 == 9)
        {
            texto2.text = not9;
            com2 = polla2;
        }
        if (polla2 == 10)
        {
            texto2.text = not10;
            com2 = polla2;
        }
        if (polla2 == 11)
        {
            texto2.text = not11;
            com2 = polla2;
        }
        if (polla2 == 12)
        {
            texto2.text = not12;
            com2 = polla2;
        }
        if (polla2 == 13)
        {
            texto2.text = not13;
            com2 = polla2;
        }
        if (polla2 == 14)
        {
            texto2.text = not14;
            com2 = polla2;
        }
        if (polla2 == 15)
        {
            texto2.text = not15;
            com2 = polla2;
        }
        if (polla2 == 16)
        {
            texto2.text = not16;
            com2 = polla2;
        }
        if (polla2 == 17)
        {
            texto2.text = not17;
            com2 = polla2;
        }
        if (polla2 == 18)
        {
            texto2.text = not18;
            com2 = polla2;
        }
        if (polla2 == 19)
        {
            texto2.text = not19;
            com2 = polla2;
        }
        if (polla2 == 20)
        {
            texto2.text = not20;
            com2 = polla2;
        }
        if (polla2 == 21)
        {
            texto2.text = not21;
            com2 = polla2;
        }
        if (polla2 == 22)
        {
            texto2.text = not22;
            com2 = polla2;
        }
        if (polla2 == 23)
        {
            texto2.text = not23;
            com2 = polla2;
        }
        if (polla2 == 24)
        {
            texto2.text = not24;
            com2 = polla2;
        }
        if (polla2 == 25)
        {
            texto2.text = not25;
            com2 = polla2;
        }
        if (polla2 == 26)
        {
            texto2.text = not26;
            com2 = polla2;
        }
        if (polla2 == 27)
        {
            texto2.text = not27;
            com2 = polla2;
        }
        if (polla2 == 28)
        {
            texto2.text = not28;
            com2 = polla2;
        }
        if (polla2 == 29)
        {
            texto2.text = not29;
            com2 = polla2;
        }
        if (polla2 == 30)
        {
            texto2.text = not30;
            com2 = polla2;
        }
        if (polla2 == 31)
        {
            texto2.text = not31;
            com2 = polla2;
        }
        if (polla2 == 32)
        {
            texto2.text = not32;
            com2 = polla2;
        }
        if (polla2 == 33)
        {
            texto2.text = not33;
            com2 = polla2;
        }
        if (polla2 == 34)
        {
            texto2.text = not34;
            com2 = polla2;
        }
        if (polla2 == 35)
        {
            texto2.text = not35;
            com2 = polla2;
        }
        if (polla2 == 36)
        {
            texto2.text = not36;
            com2 = polla2;
        }
        if (polla2 == 37)
        {
            texto2.text = not37;
            com2 = polla2;
        }
        if (polla2 == 38)
        {
            texto2.text = not38;
            com2 = polla2;
        }
        if (polla2 == 39)
        {
            texto2.text = not39;
            com2 = polla2;
        }
        if (polla2 == 40)
        {
            texto2.text = not40;
            com2 = polla2;
        }
        if (polla2 == 41)
        {
            texto2.text = not41;
            com2 = polla2;
        }







        if (com1 == com2)
        {
            siguiente();
        }


    }






}
