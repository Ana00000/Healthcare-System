﻿$(document).ready(function () {
	$("#btnRegister").click(function () {
		var PharmacyName = $("#txtPhName").val();
		var Key = $("#txtAPIKey").val();
		var Url = $("#txtUrl").val();
		var Subscribed = $("#subscribe").is(":checked")
		$.post({
			url: 'http://localhost:63251/api/registration',
			data: JSON.stringify({ Key: Key, PharmacyName: PharmacyName, Url: Url,Subscribed:Subscribed}),
			contentType: 'application/json',
			success: function () {
				alert("Succes registration");
				location.href = "../index.html";
			},
			error: function (message) {
				alert("Failed registration! Pharmacy with that api key already exsists.")
			}
		});
	});
});
