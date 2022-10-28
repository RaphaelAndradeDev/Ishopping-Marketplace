

var str, oldName, oldGoogleFonts, result = [];


function GetDefaultForm() {    
    clear();
}

function notNull(value)
{
    if (value == undefined || value == "")
        return "0";
    return value;
}


// Configurações
$(document).ready(function () {
    // Habilita Salvar
    $('input,textarea,.dropdown-toggle').not(".btn-primary").on('change', function () {
        $('#salvar').prop('disabled', false);
    });

    oldGoogleFonts = $("#ggf").val();
})


// Function for ranger slider 
$(document).ready(function () {

    function onRangeChange(rangeInputElmt, listener) {

        var inputEvtHasNeverFired = true;
        var rangeValue = { current: undefined, mostRecent: undefined };

        rangeInputElmt.addEventListener("input", function (evt) {
            inputEvtHasNeverFired = false;
            rangeValue.current = evt.target.value;
            if (rangeValue.current !== rangeValue.mostRecent) {
                listener(evt);
            }
            rangeValue.mostRecent = rangeValue.current;
        });

        rangeInputElmt.addEventListener("change", function (evt) {
            if (inputEvtHasNeverFired) {
                listener(evt);
            }
        });
    }

    // ################ DEFAULT ######################

    // letter-spacing line-height
    var myRangeInputElmt69 = document.querySelector("#despc");
    var myRangeValPar69 = document.querySelector("#despcp span");
    var myListener = function (myEvt) {
        myRangeValPar69.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt69, myListener);

    var myRangeInputElmt70 = document.querySelector("#despl");
    var myRangeValPar70 = document.querySelector("#desplp span");
    var myListener = function (myEvt) {
        myRangeValPar70.innerHTML = myEvt.target.value + "%";
    };
    onRangeChange(myRangeInputElmt70, myListener);


    // default text-shadow
    var myRangeInputElmt1 = document.querySelector("#dtextShadowPx1");
    var myRangeValPar1 = document.querySelector("#dtextShadowp1 span");
    var myListener = function (myEvt) {
        myRangeValPar1.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt1, myListener);

    var myRangeInputElmt2 = document.querySelector("#dtextShadowPx2");
    var myRangeValPar2 = document.querySelector("#dtextShadowp2 span");
    var myListener = function (myEvt) {
        myRangeValPar2.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt2, myListener);

    var myRangeInputElmt3 = document.querySelector("#dtextShadowPx3");
    var myRangeValPar3 = document.querySelector("#dtextShadowp3 span");
    var myListener = function (myEvt) {
        myRangeValPar3.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt3, myListener);

    // default box-shadow
    var myRangeInputElmt4 = document.querySelector("#dboxShadowPx1");
    var myRangeValPar4 = document.querySelector("#dboxShadowp1 span");
    var myListener = function (myEvt) {
        myRangeValPar4.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt4, myListener);

    var myRangeInputElmt5 = document.querySelector("#dboxShadowPx2");
    var myRangeValPar5 = document.querySelector("#dboxShadowp2 span");
    var myListener = function (myEvt) {
        myRangeValPar5.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt5, myListener);

    var myRangeInputElmt6 = document.querySelector("#dboxShadowPx3");
    var myRangeValPar6 = document.querySelector("#dboxShadowp3 span");
    var myListener = function (myEvt) {
        myRangeValPar6.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt6, myListener);

    var myRangeInputElmt7 = document.querySelector("#dboxShadowPx4");
    var myRangeValPar7 = document.querySelector("#dboxShadowp4 span");
    var myListener = function (myEvt) {
        myRangeValPar7.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt7, myListener);

    // default border
    var myRangeInputElmt8 = document.querySelector("#dbr");
    var myRangeValPar8 = document.querySelector("#dbrp span");
    var myListener = function (myEvt) {
        myRangeValPar8.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt8, myListener);

    var myRangeInputElmt9 = document.querySelector("#dbvl");
    var myRangeValPar9 = document.querySelector("#dbvlp span");
    var myListener = function (myEvt) {
        myRangeValPar9.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt9, myListener);

    // span size
    var myRangeInputElmt43 = document.querySelector("#dpv");
    var myRangeValPar43 = document.querySelector("#dpvp span");
    var myListener = function (myEvt) {
        myRangeValPar43.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt43, myListener);

    var myRangeInputElmt44 = document.querySelector("#dph");
    var myRangeValPar44 = document.querySelector("#dphp span");
    var myListener = function (myEvt) {
        myRangeValPar44.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt44, myListener);

    // default transform
    var myRangeInputElmt45 = document.querySelector("#dtransformrv");
    var myRangeValPar45 = document.querySelector("#dtransformr span");
    var myListener = function (myEvt) {
        myRangeValPar45.innerHTML = myEvt.target.value + " grau(s)";
    };
    onRangeChange(myRangeInputElmt45, myListener);

    var myRangeInputElmt46 = document.querySelector("#dtransformskv");
    var myRangeValPar46 = document.querySelector("#dtransformsk span");
    var myListener = function (myEvt) {
        myRangeValPar46.innerHTML = myEvt.target.value + " grau(s)";
    };
    onRangeChange(myRangeInputElmt46, myListener);

    var myRangeInputElmt47 = document.querySelector("#dtransformtvpx");
    var myRangeValPar47 = document.querySelector("#dtransformtv span");
    var myListener = function (myEvt) {
        myRangeValPar47.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt47, myListener);

    var myRangeInputElmt48 = document.querySelector("#dtransformthpx");
    var myRangeValPar48 = document.querySelector("#dtransformth span");
    var myListener = function (myEvt) {
        myRangeValPar48.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt48, myListener);

    var myRangeInputElmt49 = document.querySelector("#dtransformsvpx");
    var myRangeValPar49 = document.querySelector("#dtransformsv span");
    var myListener = function (myEvt) {
        myRangeValPar49.innerHTML = myEvt.target.value + "/10";
    };
    onRangeChange(myRangeInputElmt49, myListener);

    var myRangeInputElmt50 = document.querySelector("#dtransformshpx");
    var myRangeValPar50 = document.querySelector("#dtransformsh span");
    var myListener = function (myEvt) {
        myRangeValPar50.innerHTML = myEvt.target.value + "/10";
    };
    onRangeChange(myRangeInputElmt50, myListener);



    // ################ HOVER ######################

    // letter-spacing line-height
    var myRangeInputElmt71 = document.querySelector("#hespc");
    var myRangeValPar71 = document.querySelector("#hespcp span");
    var myListener = function (myEvt) {
        myRangeValPar71.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt71, myListener);

    var myRangeInputElmt72 = document.querySelector("#hespl");
    var myRangeValPar72 = document.querySelector("#hesplp span");
    var myListener = function (myEvt) {
        myRangeValPar72.innerHTML = myEvt.target.value + "%";
    };
    onRangeChange(myRangeInputElmt72, myListener);

    // hover text-shadow
    var myRangeInputElmt10 = document.querySelector("#htextShadowPx1");
    var myRangeValPar10 = document.querySelector("#htextShadowp1 span");
    var myListener = function (myEvt) {
        myRangeValPar10.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt10, myListener);

    var myRangeInputElmt11 = document.querySelector("#htextShadowPx2");
    var myRangeValPar11 = document.querySelector("#htextShadowp2 span");
    var myListener = function (myEvt) {
        myRangeValPar11.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt11, myListener);

    var myRangeInputElmt12 = document.querySelector("#htextShadowPx3");
    var myRangeValPar12 = document.querySelector("#htextShadowp3 span");
    var myListener = function (myEvt) {
        myRangeValPar12.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt12, myListener);

    // hover box-shadow
    var myRangeInputElmt13 = document.querySelector("#hboxShadowPx1");
    var myRangeValPar13 = document.querySelector("#hboxShadowp1 span");
    var myListener = function (myEvt) {
        myRangeValPar13.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt13, myListener);

    var myRangeInputElmt14 = document.querySelector("#hboxShadowPx2");
    var myRangeValPar14 = document.querySelector("#hboxShadowp2 span");
    var myListener = function (myEvt) {
        myRangeValPar14.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt14, myListener);

    var myRangeInputElmt15 = document.querySelector("#hboxShadowPx3");
    var myRangeValPar15 = document.querySelector("#hboxShadowp3 span");
    var myListener = function (myEvt) {
        myRangeValPar15.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt15, myListener);

    var myRangeInputElmt16 = document.querySelector("#hboxShadowPx4");
    var myRangeValPar16 = document.querySelector("#hboxShadowp4 span");
    var myListener = function (myEvt) {
        myRangeValPar16.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt16, myListener);

    // hover border
    var myRangeInputElmt17 = document.querySelector("#hbr");
    var myRangeValPar17 = document.querySelector("#hbrp span");
    var myListener = function (myEvt) {
        myRangeValPar17.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt17, myListener);

    var myRangeInputElmt18 = document.querySelector("#hbvl");
    var myRangeValPar18 = document.querySelector("#hbvlp span");
    var myListener = function (myEvt) {
        myRangeValPar18.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt18, myListener);

    // hover size
    var myRangeInputElmt41 = document.querySelector("#hpv");
    var myRangeValPar41 = document.querySelector("#hpvp span");
    var myListener = function (myEvt) {
        myRangeValPar41.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt41, myListener);

    var myRangeInputElmt42 = document.querySelector("#hph");
    var myRangeValPar42 = document.querySelector("#hphp span");
    var myListener = function (myEvt) {
        myRangeValPar42.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt42, myListener);
    
    // hover transform
    var myRangeInputElmt51 = document.querySelector("#htransformrv");
    var myRangeValPar51 = document.querySelector("#htransformr span");
    var myListener = function (myEvt) {
        myRangeValPar51.innerHTML = myEvt.target.value + " grau(s)";
    };
    onRangeChange(myRangeInputElmt51, myListener);

    var myRangeInputElmt52 = document.querySelector("#htransformskv");
    var myRangeValPar52 = document.querySelector("#htransformsk span");
    var myListener = function (myEvt) {
        myRangeValPar52.innerHTML = myEvt.target.value + " grau(s)";
    };
    onRangeChange(myRangeInputElmt52, myListener);

    var myRangeInputElmt53 = document.querySelector("#htransformtvpx");
    var myRangeValPar53 = document.querySelector("#htransformtv span");
    var myListener = function (myEvt) {
        myRangeValPar53.innerHTML = myEvt.target.value + " px";
    };
    onRangeChange(myRangeInputElmt53, myListener);

    var myRangeInputElmt54 = document.querySelector("#htransformthpx");
    var myRangeValPar54 = document.querySelector("#htransformth span");
    var myListener = function (myEvt) {
        myRangeValPar54.innerHTML = myEvt.target.value + " px";
    };
    onRangeChange(myRangeInputElmt54, myListener);

    var myRangeInputElmt55 = document.querySelector("#htransformsvpx");
    var myRangeValPar55 = document.querySelector("#htransformsv span");
    var myListener = function (myEvt) {
        myRangeValPar55.innerHTML = myEvt.target.value + "/10";
    };
    onRangeChange(myRangeInputElmt55, myListener);

    var myRangeInputElmt56 = document.querySelector("#htransformshpx");
    var myRangeValPar56 = document.querySelector("#htransformsh span");
    var myListener = function (myEvt) {
        myRangeValPar56.innerHTML = myEvt.target.value + "/10";
    };
    onRangeChange(myRangeInputElmt56, myListener);


    // ################ ACTIVE ######################

    // letter-spacing line-height
    var myRangeInputElmt73 = document.querySelector("#aespc");
    var myRangeValPar73 = document.querySelector("#aespcp span");
    var myListener = function (myEvt) {
        myRangeValPar73.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt73, myListener);

    var myRangeInputElmt74 = document.querySelector("#aespl");
    var myRangeValPar74 = document.querySelector("#aesplp span");
    var myListener = function (myEvt) {
        myRangeValPar74.innerHTML = myEvt.target.value + "%";
    };
    onRangeChange(myRangeInputElmt74, myListener);

    // active text-shadow
    var myRangeInputElmt19 = document.querySelector("#atextShadowPx1");
    var myRangeValPar19 = document.querySelector("#atextShadowp1 span");
    var myListener = function (myEvt) {
        myRangeValPar19.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt19, myListener);

    var myRangeInputElmt20 = document.querySelector("#atextShadowPx2");
    var myRangeValPar20 = document.querySelector("#atextShadowp2 span");
    var myListener = function (myEvt) {
        myRangeValPar20.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt20, myListener);

    var myRangeInputElmt21 = document.querySelector("#atextShadowPx3");
    var myRangeValPar21 = document.querySelector("#atextShadowp3 span");
    var myListener = function (myEvt) {
        myRangeValPar21.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt21, myListener);

    // active box-shadow
    var myRangeInputElmt22 = document.querySelector("#aboxShadowPx1");
    var myRangeValPar22 = document.querySelector("#aboxShadowp1 span");
    var myListener = function (myEvt) {
        myRangeValPar22.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt22, myListener);

    var myRangeInputElmt23 = document.querySelector("#aboxShadowPx2");
    var myRangeValPar23 = document.querySelector("#aboxShadowp2 span");
    var myListener = function (myEvt) {
        myRangeValPar23.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt23, myListener);

    var myRangeInputElmt24 = document.querySelector("#aboxShadowPx3");
    var myRangeValPar24 = document.querySelector("#aboxShadowp3 span");
    var myListener = function (myEvt) {
        myRangeValPar24.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt24, myListener);

    var myRangeInputElmt25 = document.querySelector("#aboxShadowPx4");
    var myRangeValPar25 = document.querySelector("#aboxShadowp4 span");
    var myListener = function (myEvt) {
        myRangeValPar25.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt25, myListener);

    // active border
    var myRangeInputElmt26 = document.querySelector("#abr");
    var myRangeValPar26 = document.querySelector("#abrp span");
    var myListener = function (myEvt) {
        myRangeValPar26.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt26, myListener);

    var myRangeInputElmt27 = document.querySelector("#abvl");
    var myRangeValPar27 = document.querySelector("#abvlp span");
    var myListener = function (myEvt) {
        myRangeValPar27.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt27, myListener);

    // active size
    var myRangeInputElmt39 = document.querySelector("#apv");
    var myRangeValPar39 = document.querySelector("#apvp span");
    var myListener = function (myEvt) {
        myRangeValPar39.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt39, myListener);

    var myRangeInputElmt40 = document.querySelector("#aph");
    var myRangeValPar40 = document.querySelector("#aphp span");
    var myListener = function (myEvt) {
        myRangeValPar40.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt40, myListener);
    
    // active transform
    var myRangeInputElmt57 = document.querySelector("#atransformrv");
    var myRangeValPar57 = document.querySelector("#atransformr span");
    var myListener = function (myEvt) {
        myRangeValPar57.innerHTML = myEvt.target.value + " grau(s)";
    };
    onRangeChange(myRangeInputElmt57, myListener);

    var myRangeInputElmt58 = document.querySelector("#atransformskv");
    var myRangeValPar58 = document.querySelector("#atransformsk span");
    var myListener = function (myEvt) {
        myRangeValPar58.innerHTML = myEvt.target.value + " grau(s)";
    };
    onRangeChange(myRangeInputElmt58, myListener);

    var myRangeInputElmt59 = document.querySelector("#atransformtvpx");
    var myRangeValPar59 = document.querySelector("#atransformtv span");
    var myListener = function (myEvt) {
        myRangeValPar59.innerHTML = myEvt.target.value + " px";
    };
    onRangeChange(myRangeInputElmt59, myListener);

    var myRangeInputElmt60 = document.querySelector("#atransformthpx");
    var myRangeValPar60 = document.querySelector("#atransformth span");
    var myListener = function (myEvt) {
        myRangeValPar60.innerHTML = myEvt.target.value + " px";
    };
    onRangeChange(myRangeInputElmt60, myListener);

    var myRangeInputElmt61 = document.querySelector("#atransformsvpx");
    var myRangeValPar61 = document.querySelector("#atransformsv span");
    var myListener = function (myEvt) {
        myRangeValPar61.innerHTML = myEvt.target.value + "/10";
    };
    onRangeChange(myRangeInputElmt61, myListener);

    var myRangeInputElmt62 = document.querySelector("#atransformshpx");
    var myRangeValPar62 = document.querySelector("#atransformsh span");
    var myListener = function (myEvt) {
        myRangeValPar62.innerHTML = myEvt.target.value + "/10";
    };
    onRangeChange(myRangeInputElmt62, myListener);


    // ################ SPAN ######################

    // letter-spacing line-height
    var myRangeInputElmt75 = document.querySelector("#sespc");
    var myRangeValPar75 = document.querySelector("#sespcp span");
    var myListener = function (myEvt) {
        myRangeValPar75.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt75, myListener);

    var myRangeInputElmt76 = document.querySelector("#sespl");
    var myRangeValPar76 = document.querySelector("#sesplp span");
    var myListener = function (myEvt) {
        myRangeValPar76.innerHTML = myEvt.target.value + "%";
    };
    onRangeChange(myRangeInputElmt76, myListener);

    // span text-shadow
    var myRangeInputElmt28 = document.querySelector("#stextShadowPx1");
    var myRangeValPar28 = document.querySelector("#stextShadowp1 span");
    var myListener = function (myEvt) {
        myRangeValPar28.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt28, myListener);

    var myRangeInputElmt29 = document.querySelector("#stextShadowPx2");
    var myRangeValPar29 = document.querySelector("#stextShadowp2 span");
    var myListener = function (myEvt) {
        myRangeValPar29.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt29, myListener);

    var myRangeInputElmt30 = document.querySelector("#stextShadowPx3");
    var myRangeValPar30 = document.querySelector("#stextShadowp3 span");
    var myListener = function (myEvt) {
        myRangeValPar30.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt30, myListener);

    // span box-shadow
    var myRangeInputElmt31 = document.querySelector("#sboxShadowPx1");
    var myRangeValPar31 = document.querySelector("#sboxShadowp1 span");
    var myListener = function (myEvt) {
        myRangeValPar31.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt31, myListener);

    var myRangeInputElmt32 = document.querySelector("#sboxShadowPx2");
    var myRangeValPar32 = document.querySelector("#sboxShadowp2 span");
    var myListener = function (myEvt) {
        myRangeValPar32.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt32, myListener);

    var myRangeInputElmt33 = document.querySelector("#sboxShadowPx3");
    var myRangeValPar33 = document.querySelector("#sboxShadowp3 span");
    var myListener = function (myEvt) {
        myRangeValPar33.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt33, myListener);

    var myRangeInputElmt34 = document.querySelector("#sboxShadowPx4");
    var myRangeValPar34 = document.querySelector("#sboxShadowp4 span");
    var myListener = function (myEvt) {
        myRangeValPar34.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt34, myListener);

    // span border
    var myRangeInputElmt35 = document.querySelector("#sbr");
    var myRangeValPar35 = document.querySelector("#sbrp span");
    var myListener = function (myEvt) {
        myRangeValPar35.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt35, myListener);

    var myRangeInputElmt36 = document.querySelector("#sbvl");
    var myRangeValPar36 = document.querySelector("#sbvlp span");
    var myListener = function (myEvt) {
        myRangeValPar36.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt36, myListener);

    // span size
    var myRangeInputElmt37 = document.querySelector("#spv");
    var myRangeValPar37 = document.querySelector("#spvp span");
    var myListener = function (myEvt) {
        myRangeValPar37.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt37, myListener);

    var myRangeInputElmt38 = document.querySelector("#sph");
    var myRangeValPar38 = document.querySelector("#sphp span");
    var myListener = function (myEvt) {
        myRangeValPar38.innerHTML = myEvt.target.value + "px";
    };
    onRangeChange(myRangeInputElmt38, myListener);


    // span transform
    var myRangeInputElmt63 = document.querySelector("#stransformrv");
    var myRangeValPar63 = document.querySelector("#stransformr span");
    var myListener = function (myEvt) {
        myRangeValPar63.innerHTML = myEvt.target.value + " grau(s)";
    };
    onRangeChange(myRangeInputElmt63, myListener);

    var myRangeInputElmt64 = document.querySelector("#stransformskv");
    var myRangeValPar64 = document.querySelector("#stransformsk span");
    var myListener = function (myEvt) {
        myRangeValPar64.innerHTML = myEvt.target.value + " grau(s)";
    };
    onRangeChange(myRangeInputElmt64, myListener);

    var myRangeInputElmt65 = document.querySelector("#stransformtvpx");
    var myRangeValPar65 = document.querySelector("#stransformtv span");
    var myListener = function (myEvt) {
        myRangeValPar65.innerHTML = myEvt.target.value + " px";
    };
    onRangeChange(myRangeInputElmt65, myListener);

    var myRangeInputElmt66 = document.querySelector("#stransformthpx");
    var myRangeValPar66 = document.querySelector("#stransformth span");
    var myListener = function (myEvt) {
        myRangeValPar66.innerHTML = myEvt.target.value + " px";
    };
    onRangeChange(myRangeInputElmt66, myListener);

    var myRangeInputElmt67 = document.querySelector("#stransformsvpx");
    var myRangeValPar67 = document.querySelector("#stransformsv span");
    var myListener = function (myEvt) {
        myRangeValPar67.innerHTML = myEvt.target.value + "/10";
    };
    onRangeChange(myRangeInputElmt67, myListener);

    var myRangeInputElmt68 = document.querySelector("#stransformshpx");
    var myRangeValPar68 = document.querySelector("#stransformsh span");
    var myListener = function (myEvt) {
        myRangeValPar68.innerHTML = myEvt.target.value + "/10";
    };
    onRangeChange(myRangeInputElmt68, myListener);

});


// Load fonts
$(document).ready(function () {
    var fonts = [
        'Baskerville',
        'Baskerville Old Face',
        'Goudy Old Style',
        'Palatino',
        'Palatino LT STD',
        'Palatino Linotype',
        'Bodoni MT', 'Didot',
        'Didot LT STD',
        'Book Antiqua',
        'Garamond',
        'Times New Roman',
        'Georgia', 'Times',
        'Century Gothic',
        'Geneva',
        'AppleGothic',
        'Tahoma',
        'Verdana',
        'Segoe',
        'Arial',
        'Arial Narrow',
        'Helvetica Condensed',
        'Helvetica',
        'Trebuchet MS',
        'Lucida Grande',
        'Lucida Sans Unicode',
        'Lucida Sans',
        'Consolas',
        'Lucida Sans Typewriter',
        'Lucida Console',
        'Monaco',
        'Bitstream Vera Sans Mono'
    ];
    $.each(fonts.sort(), function (index, value) {
        $(".dropdownFont").append('<li><a>' + value + '</a></li>');
    });

    var transition = [
        'background-color',
        'background-position',
        'border-bottom-color',
        'border-bottom-width',
        'border-left-color',
        'border-left-width',
        'border-right-color',
        'border-right-width',
        'border-spacing',
        'border-top-color',
        'border-top-width',
        'bottom',
        'clip',
        'color',
        'font-size',
        'font-weight',
        'height',
        'left',
        'letter-spacing',
        'line-height',
        'margin-bottom',
        'margin-left',
        'margin-right',
        'margin-top',
        'max-height',
        'max-width',
        'min-height',
        'min-width',
        'opacity',
        'outline-color',
        'outline-width',
        'padding-bottom',
        'padding-left',
        'padding-right',
        'padding-top',
        'right',
        'text-indent',
        'text-shadow',
        'top',
        'vertical-align',
        'visibility',
        'width',
        'word-spacing'
    ];
    $.each(transition.sort(), function (index, value) {
        $(".dropdownTransition").append('<li><a>' + value + '</a></li>');
    });
});


// Load data
$(document).ready(function () {

    $("#load").on('click', function () {
        txt = $("#className").text();
        if (txt != "Selecione uma classe") GetResult();
    });
    
    function GetResult() {
        $.ajax({
            url: '/StyleClass/GetResult',
            type: 'POST',
            data: { term: txt },
            dataType: "json"
        })
        .success(function (data) {
            if (data) {
                id = (data.Id);
                oldName = data.ClassName;
                $("#cn").val(data.ClassName);
                $("#cf").val(data.ClassFor);                

                // default
                $("#userDefault").prop("checked", data.UserDefault);
                $("#dtext").prop("checked", data.DefaultAlterText);
                $("#dsize").prop("checked", data.DefaultAlterSize);
                $("#dborder").prop("checked", data.DefaultAlterBorder);
                $("#dtextshadow").prop("checked", data.DefaultAlterTextShadow);
                $("#dboxshadow").prop("checked", data.DefaultAlterBoxShadow);
                $("#dtransform").prop("checked", data.DefaultUserTransform);
                $("#dtransition").prop("checked", data.DefaultUserTransition);

                $("#dff").val(data.DefaultFontFamily);
                $("#dfw").text(data.DefaultFontWeight);
                $("#dfst").text(data.DefaultFontStyle);

                $("#despc").val(notNull(data.DefaultLetterSpacing));
                $("#despcp span").text(notNull(data.DefaultLetterSpacing) + "px");
                $("#despl").val(notNull(data.DefaultLineHeight));
                $("#desplp span").text(notNull(data.DefaultLineHeight) + "%");
                                          
                if (data.DefaultColor) $('#indc').colorpicker('setValue', data.DefaultColor);
                if (data.DefaultBackgroundColor) $('#indbc').colorpicker('setValue', data.DefaultBackgroundColor);
                $("#dc").val(data.DefaultColor);
                $("#dbc").val(data.DefaultBackgroundColor);

                $("#dtransformrv").val(data.DefaultTransformRotate);
                $("#dtransformr span").text(data.DefaultTransformRotate + " grau(s)");
                $("#dtransformskv").val(data.DefaultTransformSkew);
                $("#dtransformsk span").text(data.DefaultTransformSkew + " grau(s)");
                $("#dtransformsvpx").val(parseFloat(data.DefaultTransformScaleX) * 10);
                $("#dtransformsv span").text(parseFloat(data.DefaultTransformScaleX) * 10 + "/10");
                $("#dtransformshpx").val(parseFloat(data.DefaultTransformScaleY) * 10);
                $("#dtransformsh span").text(parseFloat(data.DefaultTransformScaleY) * 10 + "/10");
                $("#dtransformtvpx").val(data.DefaultTransformTranslateX);
                $("#dtransformtv span").text(data.DefaultTransformTranslateX + "px");
                $("#dtransformthpx").val(data.DefaultTransformTranslateY);
                $("#dtransformth span").text(data.DefaultTransformTranslateY + "px");

                $("#dtranstitionproperty").val(data.DefaultTransitionProperty);
                $("#dtransitionfunction").text(data.DefaultTransitionFunction);
                $("#dtransitiondelay").val(data.DefaultTransitionDelay);

                str = data.DefaultFontSize;
                result = str.split(",");
                $("#dfsv").val(result[0]);
                $("#dfsl").html(result[1] + ' <span class="caret"></span>');

                str = data.DefaultTextShadow;
                result = str.split(",");
                $("#dtextShadowPx1").val(result[0]);
                $("#dtextShadowp1 span").text(result[0] + "px");
                $("#dtextShadowPx2").val(result[1]);
                $("#dtextShadowp2 span").text(result[1] + "px");
                $("#dtextShadowPx3").val(result[2]);
                $("#dtextShadowp3 span").text(result[2] + "px");
                
                if (result[3]) $('#indtextShadowColor').colorpicker('setValue', result[3]);
                $("#dtextShadowColor").val(result[3]);

                str = data.DefaultBoxShadow;
                result = str.split(",");
                $("#dboxShadowPx1").val(result[0]);
                $("#dboxShadowp1 span").text(result[0] + "px");
                $("#dboxShadowPx2").val(result[1]);
                $("#dboxShadowp2 span").text(result[1] + "px");
                $("#dboxShadowPx3").val(result[2]);
                $("#dboxShadowp3 span").text(result[2] + "px");
                $("#dboxShadowPx4").val(result[3]);
                $("#dboxShadowp4 span").text(result[3] + "px");
                
                if (result[4]) $('#indboxShadowColor').colorpicker('setValue', result[4]);
                $("#dboxShadowColor").val(result[4]);

                $("#dbr").val(data.DefaultBorderRadius);
                $("#dbrp span").text(data.DefaultBorderRadius + "px");

                str = data.DefaultBorder;
                result = str.split(",");
                $("#dbvl").val(result[0]);
                $("#dbvlp span").text(result[0] + "px");
                
                if (result[1]) $('#indbcl').colorpicker('setValue', result[1]);
                $("#dbcl").val(result[1]);

                str = data.DefaultPadding;
                result = str.split(",");
                $("#dpv").val(result[0]);
                $("#dpvp span").text(result[0] + "px");
                $("#dph").val(result[1]);
                $("#dphp span").text(result[1] + "px");

                // mouse hover
                $("#userHover").prop("checked", data.UserHover);
                $("#htext").prop("checked", data.HoverAlterText);
                $("#hsize").prop("checked", data.HoverAlterSize);
                $("#hborder").prop("checked", data.HoverAlterBorder);
                $("#htextshadow").prop("checked", data.HoverAlterTextShadow);
                $("#hboxshadow").prop("checked", data.HoverAlterBoxShadow);
                $("#htransform").prop("checked", data.HoverUserTransform);

                $("#hff").val(data.HoverFontFamily);
                $("#hfw").text(data.HoverFontWeight);
                $("#hfst").text(data.HoverFontStyle);

                $("#hespc").val(notNull(data.HoverLetterSpacing));
                $("#hespcp span").text(notNull(data.HoverLetterSpacing) + "px");
                $("#hespl").val(notNull(data.HoverLineHeight));
                $("#hesplp span").text(notNull(data.HoverLineHeight) + "%");
               
                if (data.HoverColor) $('#inhc').colorpicker('setValue', data.HoverColor);
                if (data.HoverBackgroundColor) $('#inhbc').colorpicker('setValue', data.HoverBackgroundColor);
                $("#hc").val(data.HoverColor);
                $("#hbc").val(data.HoverBackgroundColor);

                $("#htransformrv").val(data.HoverTransformRotate);
                $("#htransformr span").text(data.HoverTransformRotate + " grau(s)");
                $("#htransformskv").val(data.HoverTransformSkew);
                $("#htransformsk span").text(data.HoverTransformSkew + " grau(s)");
                $("#htransformsvpx").val(parseFloat(data.HoverTransformScaleX) * 10);
                $("#htransformsv span").text(parseFloat(data.HoverTransformScaleX) * 10 + "/10");
                $("#htransformshpx").val(parseFloat(data.HoverTransformScaleY) * 10);
                $("#htransformsh span").text(parseFloat(data.HoverTransformScaleY) * 10 + "/10");
                $("#htransformtvpx").val(data.HoverTransformTranslateX);
                $("#htransformtv span").text(data.HoverTransformTranslateX + "px");
                $("#htransformthpx").val(data.HoverTransformTranslateY);
                $("#htransformth span").text(data.HoverTransformTranslateY + "px");

                str = data.HoverFontSize;
                result = str.split(",");
                $("#hfsv").val(result[0]);
                $("#hfsl").text(result[1]);

                str = data.HoverTextShadow;
                result = str.split(",");
                $("#htextShadowPx1").val(result[0]);
                $("#htextShadowp1 span").text(result[0] + "px");
                $("#htextShadowPx2").val(result[1]);
                $("#htextShadowp2 span").text(result[1] + "px");
                $("#htextShadowPx3").val(result[2]);
                $("#htextShadowp3 span").text(result[2] + "px");
                
                if (result[3]) $('#inhtextShadowColor').colorpicker('setValue', result[3]);
                $("#htextShadowColor").val(result[3]);

                str = data.HoverBoxShadow;
                result = str.split(",");
                $("#hboxShadowPx1").val(result[0]);
                $("#hboxShadowp1 span").text(result[0] + "px");
                $("#hboxShadowPx2").val(result[1]);
                $("#hboxShadowp2 span").text(result[1] + "px");
                $("#hboxShadowPx3").val(result[2]);
                $("#hboxShadowp3 span").text(result[2] + "px");
                $("#hboxShadowPx4").val(result[3]);
                $("#hboxShadowp4 span").text(result[3] + "px");
                
                if (result[4]) $('#inhboxShadowColor').colorpicker('setValue', result[4]);
                $("#hboxShadowColor").val(result[4]);

                $("#hbr").val(data.HoverBorderRadius);
                $("#hbrp span").text(data.HoverBorderRadius + "px");

                str = data.HoverBorder;
                result = str.split(",");
                $("#hbvl").val(result[0]);
                $("#hbvlp span").text(result[0] + "px");
                
                if (result[1]) $('#inhbcl').colorpicker('setValue', result[1]);
                $("#hbcl").val(result[1]);

                str = data.HoverPadding;
                result = str.split(",");
                $("#hpv").val(result[0]);
                $("#hpvp span").text(result[0] + "px");
                $("#hph").val(result[1]);
                $("#hphp span").text(result[1] + "px");

                // active
                $("#userActive").prop("checked", data.UserActive);
                $("#atext").prop("checked", data.ActiveAlterText);
                $("#asize").prop("checked", data.ActiveAlterSize);
                $("#aborder").prop("checked", data.ActiveAlterBorder);
                $("#atextshadow").prop("checked", data.ActiveAlterTextShadow);
                $("#aboxshadow").prop("checked", data.ActiveAlterBoxShadow);
                $("#atransform").prop("checked", data.ActiveUserTransform);

                $("#aff").val(data.ActiveFontFamily);
                $("#afw").text(data.ActiveFontWeight);
                $("#afst").text(data.ActiveFontStyle);

                $("#aespc").val(notNull(data.ActiveLetterSpacing));
                $("#aespcp span").text(notNull(data.ActiveLetterSpacing) + "px");
                $("#aespl").val(notNull(data.ActiveLineHeight));
                $("#aesplp span").text(notNull(data.ActiveLineHeight) + "%");
                
                if (data.ActiveColor) $('#inac').colorpicker('setValue', data.ActiveColor);
                if (data.ActiveBackgroundColor) $('#inabc').colorpicker('setValue', data.ActiveBackgroundColor);
                $("#ac").val(data.ActiveColor);
                $("#abc").val(data.ActiveBackgroundColor);

                $("#atransformrv").val(data.ActiveTransformRotate);
                $("#atransformr span").text(data.ActiveTransformRotate + " grau(s)");
                $("#atransformskv").val(data.ActiveTransformSkew);
                $("#atransformsk span").text(data.ActiveTransformSkew + " grau(s)");
                $("#atransformsvpx").val(parseFloat(data.ActiveTransformScaleX) * 10);
                $("#atransformsv span").text(parseFloat(data.ActiveTransformScaleX) * 10 + "/10");
                $("#atransformshpx").val(parseFloat(data.ActiveTransformScaleY) * 10);
                $("#atransformsh span").text(parseFloat(data.ActiveTransformScaleY) * 10 + "/10");
                $("#atransformtvpx").val(data.ActiveTransformTranslateX);
                $("#atransformtv span").text(data.ActiveTransformTranslateX + "px");
                $("#atransformthpx").val(data.ActiveTransformTranslateY);
                $("#atransformth span").text(data.ActiveTransformTranslateY + "px");

                str = data.ActiveFontSize;
                result = str.split(",");
                $("#afsv").val(result[0]);
                $("#afsl").text(result[1]);

                str = data.ActiveTextShadow;
                result = str.split(",");
                $("#atextShadowPx1").val(result[0]);
                $("#atextShadowp1 span").text(result[0] + "px");
                $("#atextShadowPx2").val(result[1]);
                $("#atextShadowp2 span").text(result[1] + "px");
                $("#atextShadowPx3").val(result[2]);
                $("#atextShadowp3 span").text(result[2] + "px");
                
                if (result[3]) $('#inatextShadowColor').colorpicker('setValue', result[3]);
                $("#atextShadowColor").val(result[3]);

                str = data.ActiveBoxShadow;
                result = str.split(",");
                $("#aboxShadowPx1").val(result[0]);
                $("#aboxShadowp1 span").text(result[0] + "px");
                $("#aboxShadowPx2").val(result[1]);
                $("#aboxShadowp2 span").text(result[1] + "px");
                $("#aboxShadowPx3").val(result[2]);
                $("#aboxShadowp3 span").text(result[2] + "px");
                $("#aboxShadowPx4").val(result[3]);
                $("#aboxShadowp4 span").text(result[3] + "px");
                
                if (result[4]) $('#inaboxShadowColor').colorpicker('setValue', result[4]);
                $("#aboxShadowColor").val(result[4]);

                $("#abr").val(data.ActiveBorderRadius);
                $("#abrp span").text(data.ActiveBorderRadius + "px");

                str = data.ActiveBorder;
                result = str.split(",");
                $("#abvl").val(result[0]);
                $("#abvlp span").text(result[0] + "px");
                
                if (result[1]) $('#inabcl').colorpicker('setValue', result[1]);
                $("#abcl").val(result[1]);

                str = data.ActivePadding;
                result = str.split(",");
                $("#apv").val(result[0]);
                $("#apvp span").text(result[0] + "px");
                $("#aph").val(result[1]);
                $("#aphp span").text(result[1] + "px");

                // span
                $("#userSpan").prop("checked", data.UserSpan);
                $("#stext").prop("checked", data.SpanAlterText);
                $("#ssize").prop("checked", data.SpanAlterSize);
                $("#sborder").prop("checked", data.SpanAlterBorder);
                $("#stextshadow").prop("checked", data.SpanAlterTextShadow);
                $("#sboxshadow").prop("checked", data.SpanAlterBoxShadow);
                $("#stransform").prop("checked", data.SpanUserTransform);

                $("#sff").val(data.SpanFontFamily);
                $("#sfw").text(data.SpanFontWeight);
                $("#sfst").text(data.SpanFontStyle);

                $("#sespc").val(notNull(data.SpanLetterSpacing));
                $("#sespcp span").text(notNull(data.SpanLetterSpacing) + "px");
                $("#sespl").val(notNull(data.SpanLineHeight));
                $("#sesplp span").text(notNull(data.SpanLineHeight) + "%");
                                
                if (data.SpanColor) $('#insc').colorpicker('setValue', data.SpanColor);
                if (data.SpanBackgroundColor) $('#insbc').colorpicker('setValue', data.SpanBackgroundColor);
                $("#sc").val(data.SpanColor);
                $("#sbc").val(data.SpanBackgroundColor);

                $("#stransformrv").val(data.SpanTransformRotate);
                $("#stransformr span").text(data.SpanTransformRotate + " grau(s)");
                $("#stransformskv").val(data.SpanTransformSkew);
                $("#stransformsk span").text(data.SpanTransformSkew + " grau(s)");
                $("#stransformsvpx").val(parseFloat(data.SpanTransformScaleX) * 10);
                $("#stransformsv span").text(parseFloat(data.SpanTransformScaleX) * 10 + "/10");
                $("#stransformshpx").val(parseFloat(data.SpanTransformScaleY) * 10);
                $("#stransformsh span").text(parseFloat(data.SpanTransformScaleY) * 10 + "/10");
                $("#stransformtvpx").val(data.SpanTransformTranslateX);
                $("#stransformtv span").text(data.SpanTransformTranslateX + "px");
                $("#stransformthpx").val(data.SpanTransformTranslateY);
                $("#stransformth span").text(data.SpanTransformTranslateY + "px");

                str = data.SpanFontSize;
                result = str.split(",");
                $("#sfsv").val(result[0]);
                $("#sfsl").text(result[1]);

                str = data.SpanTextShadow;
                result = str.split(",");
                $("#stextShadowPx1").val(result[0]);
                $("#stextShadowp1 span").text(result[0] + "px");
                $("#stextShadowPx2").val(result[1]);
                $("#stextShadowp2 span").text(result[1] + "px");
                $("#stextShadowPx3").val(result[2]);
                $("#stextShadowp3 span").text(result[2] + "px");
                
                if (result[3]) $('#instextShadowColor').colorpicker('setValue', result[3]);
                $("#stextShadowColor").val(result[3]);

                str = data.SpanBoxShadow;
                result = str.split(",");
                $("#sboxShadowPx1").val(result[0]);
                $("#sboxShadowp1 span").text(result[0] + "px");
                $("#sboxShadowPx2").val(result[1]);
                $("#sboxShadowp2 span").text(result[1] + "px");
                $("#sboxShadowPx3").val(result[2]);
                $("#sboxShadowp3 span").text(result[2] + "px");
                $("#sboxShadowPx4").val(result[3]);
                $("#sboxShadowp4 span").text(result[3] + "px");
                
                if (result[4]) $('#insboxShadowColor').colorpicker('setValue', result[4]);
                $("#sboxShadowColor").val(result[4]);

                $("#sbr").val(data.SpanBorderRadius);
                $("#sbrp span").text(data.SpanBorderRadius + "px");

                str = data.SpanBorder;
                result = str.split(",");
                $("#sbvl").val(result[0]);
                $("#sbvlp span").text(result[0] + "px");
                
                if (result[1]) $('#insbcl').colorpicker('setValue', result[1]);
                $("#sbcl").val(result[1]);

                str = data.SpanPadding;
                result = str.split(",");
                $("#spv").val(result[0]);
                $("#spvp span").text(result[0] + "px");
                $("#sph").val(result[1]);
                $("#sphp span").text(result[1] + "px");
            }
            else {
                jsonFileNotFound(data);
            }
        })
        .error(function (xhr, status) {
            $('#Status').html("Erro na tentativa de busca");
        })
    };
});


// Salvar Mudanças
 function Salvar() {
    data = {};

    // id
    data['Id'] = id;
    data["ClassFor"] = $("#cf").val();
    data["ClassName"] = $("#cn").val();    

    // default         
    data["UserDefault"] = $("#userDefault").prop('checked');
    data["DefaultAlterText"] = $("#dtext").prop('checked');
    data["DefaultAlterSize"] = $("#dsize").prop('checked');
    data["DefaultAlterBorder"] = $("#dborder").prop('checked');
    data["DefaultAlterTextShadow"] = $("#dtextshadow").prop('checked');
    data["DefaultAlterBoxShadow"] = $("#dboxshadow").prop('checked');
    data["DefaultUserTransform"] = $("#dtransform").prop('checked');
    data["DefaultUserTransition"] = $("#dtransition").prop('checked');

    data["DefaultFontSize"] = $("#dfsv").val() + "," + $("#dfsl").text();
    data["DefaultFontFamily"] = $("#dff").val();
    data["DefaultFontWeight"] = $("#dfw").text();
    data["DefaultFontStyle"] = $("#dfst").text();
    data["DefaultLetterSpacing"] = $("#despc").val();
    data["DefaultLineHeight"] = $("#despl").val();
    data["DefaultColor"] = $("#dc").val();
    data["DefaultBackgroundColor"] = $("#dbc").val();
    data['DefaultPadding'] = $("#dpv").val() + "," + $("#dph").val();
    data["DefaultBorderRadius"] = $("#dbr").val();
    data['DefaultBorder'] = $("#dbvl").val() + "," + $("#dbcl").val();

    data["DefaultTransformRotate"] = $("#dtransformrv").val();
    data["DefaultTransformSkew"] = $("#dtransformskv").val();
    data["DefaultTransformScaleX"] = parseInt($("#dtransformsvpx").val()) / 10;
    data["DefaultTransformScaleY"] = parseInt($("#dtransformshpx").val()) / 10;
    data["DefaultTransformTranslateX"] = $("#dtransformtvpx").val();
    data["DefaultTransformTranslateY"] = $("#dtransformthpx").val();

    data["DefaultTransitionProperty"] = $("#dtranstitionproperty").val();
    data["DefaultTransitionFunction"] = $("#dtransitionfunction").val();
    data["DefaultTransitionDelay"] = $("#dtransitiondelay").val();
   
    j = "";
    $(".dbs").each(function () {
        str = $(this).val() + ",";
        j += str;
        str = "";
    });
    data['DefaultBoxShadow'] = j.substring(0, j.length - 1);

    var j = "";  
    $(".dts").each(function () {
        str = $(this).val() + ",";
        j += str;
        str = "";
    });
    data['DefaultTextShadow'] = j.substring(0, j.length - 1);       
            
        
    // mouse hover     
    data["UserHover"] = $("#userHover").prop('checked');
    data["HoverAlterText"] = $("#htext").prop('checked');
    data["HoverAlterSize"] = $("#hsize").prop('checked');
    data["HoverAlterBorder"] = $("#hborder").prop('checked');
    data["HoverAlterTextShadow"] = $("#htextshadow").prop('checked');
    data["HoverAlterBoxShadow"] = $("#hboxshadow").prop('checked');
    data["HoverUserTransform"] = $("#htransform").prop('checked');

    data["HoverFontSize"] = $("#hfsv").val() + "," + $("#hfsl").text();
    data["HoverFontFamily"] = $("#hff").val();
    data["HoverFontWeight"] = $("#hfw").text();
    data["HoverFontStyle"] = $("#hfst").text();
    data["HoverLetterSpacing"] = $("#hespc").val();
    data["HoverLineHeight"] = $("#hespl").val();
    data["HoverColor"] = $("#hc").val();
    data["HoverBackgroundColor"] = $("#hbc").val();
    data['HoverPadding'] = $("#hpv").val() + "," + $("#hph").val();
    data["HoverBorderRadius"] = $("#hbr").val();
    data['HoverBorder'] = $("#hbvl").val() + "," + $("#hbcl").val();

    data["HoverTransformRotate"] = $("#htransformrv").val();
    data["HoverTransformSkew"] = $("#htransformskv").val();
    data["HoverTransformScaleX"] = parseInt($("#htransformsvpx").val()) / 10;
    data["HoverTransformScaleY"] = parseInt($("#htransformshpx").val()) / 10;
    data["HoverTransformTranslateX"] = $("#htransformtvpx").val();
    data["HoverTransformTranslateY"] = $("#htransformthpx").val();

    j = "";
    $(".hts").each(function () {
        str = $(this).val() + ",";
        j += str;
        str = "";
    });
    data['HoverTextShadow'] = j.substring(0, j.length - 1);

    j = "";
    $(".hbs").each(function () {
        str = $(this).val() + ",";
        j += str;
        str = "";
    });
    data['HoverBoxShadow'] = j.substring(0, j.length - 1);

    // active     
    data["UserActive"] = $("#userActive").prop('checked');
    data["ActiveAlterText"] = $("#atext").prop('checked');
    data["ActiveAlterSize"] = $("#asize").prop('checked');
    data["ActiveAlterBorder"] = $("#aborder").prop('checked');
    data["ActiveAlterTextShadow"] = $("#atextshadow").prop('checked');
    data["ActiveAlterBoxShadow"] = $("#aboxshadow").prop('checked');
    data["ActiveUserTransform"] = $("#atransform").prop('checked');

    data["ActiveFontSize"] = $("#afsv").val() + "," + $("#afsl").text();
    data["ActiveFontFamily"] = $("#aff").val();
    data["ActiveFontWeight"] = $("#afw").text();
    data["ActiveFontStyle"] = $("#afst").text();
    data["ActiveLetterSpacing"] = $("#aespc").val();
    data["ActiveLineHeight"] = $("#aespl").val();
    data["ActiveColor"] = $("#ac").val();
    data["ActiveBackgroundColor"] = $("#abc").val();
    data['ActivePadding'] = $("#apv").val() + "," + $("#aph").val();
    data["ActiveBorderRadius"] = $("#abr").val();
    data['ActiveBorder'] = $("#abvl").val() + "," + $("#abcl").val();

    data["ActiveTransformRotate"] = $("#atransformrv").val();
    data["ActiveTransformSkew"] = $("#atransformskv").val();
    data["ActiveTransformScaleX"] = parseInt($("#atransformsvpx").val()) / 10;
    data["ActiveTransformScaleY"] = parseInt($("#atransformshpx").val()) / 10;
    data["ActiveTransformTranslateX"] = $("#atransformtvpx").val();
    data["ActiveTransformTranslateY"] = $("#atransformthpx").val();

    j = "";
    $(".ats").each(function () {
        str = $(this).val() + ",";
        j += str;
        str = "";
    });
    data['ActiveTextShadow'] = j.substring(0, j.length - 1);

    j = "";
    $(".abs").each(function () {
        str = $(this).val() + ",";
        j += str;
        str = "";
    });
    data['ActiveBoxShadow'] = j.substring(0, j.length - 1);

    // span   
    data["UserSpan"] = $("#userSpan").prop('checked');
    data["SpanAlterText"] = $("#stext").prop('checked');
    data["SpanAlterSize"] = $("#ssize").prop('checked');
    data["SpanAlterBorder"] = $("#sborder").prop('checked');
    data["SpanAlterTextShadow"] = $("#stextshadow").prop('checked');
    data["SpanAlterBoxShadow"] = $("#sboxshadow").prop('checked');
    data["SpanUserTransform"] = $("#stransform").prop('checked');

    data["SpanFontSize"] = $("#sfsv").val() + "," + $("#sfsl").text();
    data["SpanFontFamily"] = $("#sff").val();
    data["SpanFontWeight"] = $("#sfw").text();
    data["SpanFontStyle"] = $("#sfst").text();
    data["SpanLetterSpacing"] = $("#sespc").val();
    data["SpanLineHeight"] = $("#sespl").val();
    data["SpanColor"] = $("#sc").val();
    data["SpanBackgroundColor"] = $("#sbc").val();
    data['SpanPadding'] = $("#spv").val() + "," + $("#sph").val();
    data["SpanBorderRadius"] = $("#sbr").val();
    data['SpanBorder'] = $("#sbvl").val() + "," + $("#sbcl").val();

    data["SpanTransformRotate"] = $("#stransformrv").val();
    data["SpanTransformSkew"] = $("#stransformskv").val();
    data["SpanTransformScaleX"] = parseInt($("#stransformsvpx").val()) / 10;
    data["SpanTransformScaleY"] = parseInt($("#stransformshpx").val()) / 10;
    data["SpanTransformTranslateX"] = $("#stransformtvpx").val();
    data["SpanTransformTranslateY"] = $("#stransformthpx").val();

    j = "";
    $(".sts").each(function () {
        str = $(this).val() + ",";
        j += str;
        str = "";
    });
    data['SpanTextShadow'] = j.substring(0, j.length - 1);

    j = "";
    $(".sbs").each(function () {
        str = $(this).val() + ",";
        j += str;
        str = "";
    });
    data['SpanBoxShadow'] = j.substring(0, j.length - 1);

    // *****************************

    var googleFonts = $("#ggf").val();

    myJSON = JSON.stringify(data);
    $.ajax({
        url: '/StyleClass/Salvar',
        data: { oldGoogleFonts: oldGoogleFonts, googleFonts: googleFonts, oldName: oldName, data: myJSON },
        type: 'POST',
        cache: false,
        headers: { "__RequestVerificationToken": token },
        dataType: "json"
    })
    .success(function (json) {
        jsonSuccess(json);
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de salvar dados");
    });    
};


// Dropdown config
 $(document).ready(function () {

    $(".dropdown-menu li a").click(function () {
        var selText = $(this).text();
        $(this).parents('.btn-group').find('.txt').text(selText);
        $(this).parents('.btn-group').find('.txt').val(selText);
        $('#salvar').prop('disabled', false);
    });

    $(document).on("click", ".scrollable-menu li a", function () {
        var selText = $(this).text();
        $(this).parents('.input-group').find('input[type="text"]').val(selText);
        $('#salvar').prop('disabled', false);
    });

    $(document).on("click", ".dropdownTransition li a", function () {
        var selText = $(this).text();
        $(this).parents('.input-group').find('input[type="text"]').val(selText + " 2s");
        $('#salvar').prop('disabled', false);
    });

    $(".dropdown-menu-right li a").click(function () {
        var selText = $(this).text();
        $(this).parents('.input-group').find('.btn').html(selText + ' <span class="caret"></span>');
        $('#salvar').prop('disabled', false);
    });

});


// Regras de validação
$(document).ready(function () {

    var hex = new RegExp(/^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$/gm);
    var rgba = new RegExp(/^rgba\((\d{1,3}),\s*(\d{1,3}),\s*(\d{1,3}),\s*(\d*(?:\.\d+)?)\)$/);
    var color = new RegExp(hex.source + "|" + rgba.source);

    $("[name='colorPicker']")
         .colorpicker()
         .on('showPicker changeColor', function (e) {
             $('#defaultForm').bootstrapValidator('revalidateField', 'dcolor');
         });

    $('#defaultForm').bootstrapValidator({     
        message: 'This value is not valid',
        fields: {
            className: {
                validators: {
                    notEmpty: { message: 'O campo Classe é requerido' },
                    regexp: {
                        regexp: /^[0-9A-Za-z]+$/,
                        message: 'Apenas letras e números são permitidos, não use espaços'
                    },
                    stringLength: { min: 4, max: 12 }
                }
            },
            classFor: {
                validators: {
                    regexp: {
                        regexp: /^[A-Za-z\s]+$/,
                        message: 'Apenas letras são permitidas'
                    },
                    stringLength: { max: 20 }
                }
            },
            fontSize: {
                validators: {
                    between: { max: 300, message: 'Font-size não deve ultrapassar o valor de 300' }
                }
            },
            pixel: {
                validators: {
                    between: { max: 300 }
                }
            },
            fontFamily: {
                validators: {
                    regexp: {
                        regexp: /^[0-9A-Za-z\s]+$/,
                        message: 'Apenas letras e números são permitidos'
                    },
                    stringLength: {
                        max: 24,
                        message: 'Font-family deve conter no máximo 24 caracteres'
                    }
                }
            },      
            dcolor: {
                validators: {
                    regexp: {
                        regexp: color,
                        message: 'Use somente cores em hexadecimal, rgb ou rgba'
                    }
                }
            },
            googleFont: {
                validators: {
                    uri: { allowLocal: false }
                }
            },
        }
    })
    .on('success.form.bv', function (e) {
        // Prevent form submission
        e.preventDefault();
        // Get the form instance
        var $form = $(e.target);
        // Get the BootstrapValidator instance
        var bv = $form.data('bootstrapValidator');
        // Call action save
        Salvar();
    });
});


