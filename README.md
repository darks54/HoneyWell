# HoneyWell

Lecteur d’imagerie matricielle Xenon 1900, http://country.honeywellaidc.com/fr-FR/Pages/Product.aspx?category=hand-held-barcode-scanner&cat=HSM&pid=1900

## Prérequis

* Microsoft .NET Framework 3.5, https://www.microsoft.com/fr-fr/download/details.aspx?id=21
* Intallation du driver The Honeywell Scanning & Mobility (HSM), http://country.honeywellaidc.com/CatalogDocuments/HSM%20USB%20Serial%20Driver%20version%203.5.5.zip

## Utilisation

* Téléchargez le fichier Honeywell.Xenon.dll
* Incluez le dans les références dans votre projet .Net
```vb.net
Imports Honeywell.Xenon
```

### Récupérer une image

```vb.net
  Dim xenon As Xenon = New Xenon("COM6")
  If xenon.GetImageJpeg("C:\temp\test.jpg") Then
      PictureBox1.Image = Image.FromFile("C:\temp\test.jpg")
  Else
      MsgBox("erreur")
  End If
  xenon.Dispose()
```
