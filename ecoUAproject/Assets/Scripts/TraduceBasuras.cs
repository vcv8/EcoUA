using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraduceBasuras : MonoBehaviour
{
    public int contentSize;
    private bool started = false;
    private string[] traducciones;
    private string[] originales;

    private void Start() {
        originales = new string[contentSize];
        traducciones = new string[contentSize];

        originales[0]   = "Bolsa de snacks.";
        traducciones[0] = "Borsa de snack.";
        originales[1]   = "Restos de manzana.";
        traducciones[1] = "Restes de poma.";
        originales[2]   = "Palo de helado.";
        traducciones[2] = "Pal de gelat.";
        originales[3]   = "Huevera.";
        traducciones[3] = "Ouera.";
        originales[4]   = "Nota.";
        traducciones[4] = "Nota.";
        originales[5]   = "Tarro.";
        traducciones[5] = "Tarro.";
        originales[6]   = "Vaso no reutilzable.";
        traducciones[6] = "Got no reutilitzable.";
        originales[7]   = "Chapa.";
        traducciones[7] = "Xapa.";
        originales[8]   = "Envase de dentífrico.";
        traducciones[8] = "Envàs de dentifrici.";
        originales[9]   = "Infusión.";
        traducciones[9] = "Infusió.";
        originales[10]   = "Agenda.";
        traducciones[10] = "Agenda.";
        originales[11]   = "Cajetilla de tabaco.";
        traducciones[11] = "Paquet de tabac.";
        originales[12]   = "Bolígrafo.";
        traducciones[12] = "Bolígraf.";
        originales[13]   = "Botellín.";
        traducciones[13] = "Botellín.";
        originales[14]   = "Cáscara de huevo.";
        traducciones[14] = "Pela d'ou.";
        originales[15]   = "Rollo de papel.";
        traducciones[15] = "Rotllo de paper.";
        originales[16]   = "Lata de conservas.";
        traducciones[16] = "Llanda de conserves.";
        originales[17]   = "Bombilla.";
        traducciones[17] = "Bombeta.";
        originales[18]   = "Envase de producto de limpieza.";
        traducciones[18] = "Envàs de producte de neteja.";
        originales[19]   = "Folio.";
        traducciones[19] = "Foli.";
        originales[20]   = "Botella de plástico.";
        traducciones[20] = "Botella de plàstic.";
        originales[21]   = "Brick de leche.";
        traducciones[21] = "Brick de llet.";
        originales[22]   = "Bote de esmalte.";
        traducciones[22] = "Pot d'esmalt.";
        originales[23]   = "Lata de refresco.";
        traducciones[23] = "Llanda de refresc.";
        originales[24]   = "Tapón de corcho.";
        traducciones[24] = "Tap de suro.";
        originales[25]   = "Botella de cristal.";
        traducciones[25] = "Botella de cristall.";
        originales[26]   = "Cepillo de dientes.";
        traducciones[26] = "Raspall de dents.";


        traduceContenido();
        started = true;
    }

    private void OnEnable() {
        if(started){
            traduceContenido();
        }
    }

    private void traduceContenido(){
        if( GameData.idioma ){
            transform.GetComponentInChildren<Text>().text = "Brosses";
            transform.GetChild(2).gameObject.GetComponentInChildren<Text>().text = "Tornar";
        }else{
            transform.GetComponentInChildren<Text>().text = "Basuras";
            transform.GetChild(2).gameObject.GetComponentInChildren<Text>().text = "Volver";
        }

        GameObject contenido = transform.GetChild(1).GetChild(0).GetChild(0).gameObject;

        for(int i = 0; i < contentSize; i++){
            GameObject elem = contenido.transform.GetChild(i).gameObject;

            if( GameData.idioma ){
                elem.GetComponentInChildren<Text>().text = traducciones[i];
            }else{
                elem.GetComponentInChildren<Text>().text = originales[i];
            }
        }
    }
}
