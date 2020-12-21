$( document ).ready(function() {
	$("#dtNascimentoPaciente").mask('00/00/0000');
	atualizarGridPacientesNovos();
	atualizarGridPacientesAtendidos();
	
	$("#cadastrarPaciente").click(function() {

		var ano = $('#dtNascimentoPaciente').val().split('/')[2];
		var mes = $('#dtNascimentoPaciente').val().split('/')[1];
		var dia = $('#dtNascimentoPaciente').val().split('/')[0];
		var paciente = 
		{ 
			'nome': 		    $('#nomePaciente').val(),
			'sexo': 			$('#sexoPaciente').val(),
			'dt_nascimento':  ano+'-'+mes+'-'+dia,
			'documento':	$('#documentoPaciente').val()
		};
		
		$.ajax({
			
					type: "POST",
				url: "https://localhost:5001/api/paciente/NovoPaciente",
				data: JSON.stringify(paciente),
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function(data){
					
					$('#modal-novoPaciente').modal('hide');
					//$('#pacientesNovos').html('<thead><tr><th>Nome</th><th></th></tr></thead><tbody id="gridPacientesNovos" name="gridPacientesNovos"></tbody>');
					atualizarGridPacientesNovos();
				},
				error: function(errMsg) {
					alert(errMsg);
				}
			
		  });
		  alert("Paciente cadastrado!");
		  location.reload();
		});
		
		$("#salvarAtendimento").click(function() {

		if($('#pacienteAtualId').val() == ''){
			alert("Selecione um paciente!");
		}else if ($('#pacienteAtualProntuario').val() == ''){
			alert("Informe os dados da consulta!");
		}else{
		var paciente = 
		{ 
			'pacienteId': 		    $('#pacienteAtualId').val(),
			'prontuario': 			$('#pacienteAtualProntuario').val(),
		};
		
		$.ajax({
			
				type: "POST",
				url: "https://localhost:5001/api/atendimento/NovoAtendimento",
				data: JSON.stringify(paciente),
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function(data){
					$('#pacienteAtual').text('Paciente ');
					$('#pacienteAtualId').val('');
					$('#pacienteAtualProntuario').val('');
					alert("Atendimento finalizado!");
					location.reload();
					atualizarGridPacientesAtendidos();
				},
				error: function(errMsg) {
					alert(errMsg);
				}
			
		  });
		  
		}
		});
		
		
		
	});



function buildHtmlTable(selector, objetoJson, colunas, botao, conteudoBotao, tipo) {

  var columns = addAllColumnHeaders(objetoJson, selector, colunas, botao);
  $(selector).html('');
	//debugger;
  for (var i = 0; i < objetoJson.length; i++) {
    var row$ = $('<tr/>');
    for (var colIndex = 0; colIndex < columns.length; colIndex++) {
      var cellValue = objetoJson[i][columns[colIndex]];
      if (cellValue == null) cellValue = "";
      row$.append($('<td/>').html(cellValue));
	  if(botao){
		row$.append($('<td/>').html('<button class="btn btn-info '+tipo+'" id ="'+objetoJson[i]['id']+'">'+conteudoBotao+'</button>'));  
	  }
    }
    $(selector).append(row$);
  }
  
}

// Adds a header row to the table and returns the set of columns.
// Need to do union of keys from all records as some records may not contain
// all records.
function addAllColumnHeaders(objetoJson, selector, colunas, botao) {
  //debugger;
  var columnSet = [];
  var headerTr$ = $('<tr/>');


  for (var i = 0; i < objetoJson.length; i++) {
    var rowHash = objetoJson[i];
    for (var key in rowHash) {
      if ($.inArray(key, columnSet) == -1) {
		if ($.inArray(key, colunas) != -1) {
			columnSet.push(key);
			//headerTr$.append($('<th/>').html(key));
		}  

      }
    }
  }
  //$(selector).append(headerTr$);

  return columnSet;
}


function atualizarGridPacientesNovos(){
	//debugger;
		$.ajax({			
		  url: 'https://localhost:5001/api/paciente/ListaPaciente',			
		  type: 'get',	
		  success: function(response){
			  //debugger;
			  tipo = ""
				buildHtmlTable("#gridPacientesNovos", response, ['nome'], true, "nova consulta", "novaconsulta");
				$(".novaconsulta").click(function(){
					atualizarProntuario(".novaconsulta", $(this).attr('id'));
				});
				atualizaDataTable("#pacientesNovos");
				}

		})
};

function atualizarProntuario(tipo, id){
		
		if(tipo == ".novaconsulta"){
			$.ajax({			
		  url: 'https://localhost:5001/api/paciente/'+id,			
		  type: 'get',	
		  success: function(response){
					var ano = response.dt_nascimento.substring(0,4);
					var mes = response.dt_nascimento.substring(5,7);
					var dia = response.dt_nascimento.substring(8,10);
					$('#pacienteAtualId').val(response.id);
					$('#pacienteAtualNome').val(response.nome);
					$('#pacienteAtualSexo').val(response.sexo);
					$('#pacienteAtualNascimento').val(dia+'/'+mes+'/'+ano);
					$('#pacienteAtualDocumento').val(response.documento);
					$('#pacienteAtualProntuario').val("");
					$('#salvarAtendimento').prop("disabled",false);
				}

			})
		}else if(tipo == ".verconsulta"){
			$.ajax({
					url: 'https://localhost:5001/api/atendimento/ListaAtendimentoSimplificado/'+id,			
					type: 'get',	
						success: function(response){
						
							var ano = response.dt_nascimento.substring(0,4);
							var mes = response.dt_nascimento.substring(5,7);
							var dia = response.dt_nascimento.substring(8,10);
							$('#pacienteAtualId').val(response.id);
							$('#pacienteAtualNome').val(response.nome);
							$('#pacienteAtualSexo').val(response.sexo);
							$('#pacienteAtualNascimento').val(dia+'/'+mes+'/'+ano);
							$('#pacienteAtualDocumento').val(response.documento);
							$('#pacienteAtualProntuario').val(response.prontuario);
							$('#salvarAtendimento').prop("disabled",true);
							$('html,body').scrollTop(0);
						
						}
					});
			
		}
};



function atualizarGridPacientesAtendidos(){
		$.ajax({			
		  url: 'https://localhost:5001/api/atendimento/ListaAtendimentoSimplificado',			
		  type: 'get',	
		  success: function(response){
			  //debugger;
				buildHtmlTable("#gridPacientesAtendidos", response, ['nome'], true, "ver consulta", "verconsulta");				
				$(".verconsulta").click(function(){
					atualizarProntuario(".verconsulta", $(this).attr('id'));
				});
				atualizaDataTable("#pacientesAtendidos");
				}
				

		})
};
	
function atualizaDataTable(tabela){

$(tabela).DataTable({
	  "sDom": '<"top"i>rt<"bottom"flp><"clear">',
	  "retrieve": true,
	  "bFilter": true,
		"bInfo": true,
		"pageLength": 5,
		"bLengthChange": false,
		"language": {		
				 
				"sEmptyTable": "Nenhum registro encontrado",
				"sInfo": "Mostrando de _START_ at&eacute; _END_ de _TOTAL_ registros",
				"sInfoEmpty": "Mostrando 0 at&eacute; 0 de 0 registros",
				"sInfoFiltered": "(Filtrados de MAX registros)",
				"sInfoPostFix": "",
				"sInfoThousands": "",
				"sLengthMenu": "_MENU_ resultados por p&aacute;gina",
				"sLoadingRecords": "Carregando...",
				"sProcessing": "Processando...",
				"sZeroRecords": "Nenhum registro encontrado",
				"sSearch": "Pesquisar",
				"oPaginate": {
					"sNext": "Pr&oacute;ximo",
					"sPrevious": "Anterior",
					"sFirst": "Primeiro",
					"sLast": "&Uacute;ltimo"
				},
				"oAria": {
					"sSortAscending": ": Ordenar colunas de forma ascendente",
					"sSortDescending": ": Ordenar colunas de forma descendente"
				}
		}
    });
	

}
