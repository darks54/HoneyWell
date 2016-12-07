# HoneyWell

Lecteur d’imagerie matricielle Xenon 1900, http://country.honeywellaidc.com/fr-FR/Pages/Product.aspx?category=hand-held-barcode-scanner&cat=HSM&pid=1900

## Prérequis

* Microsoft .NET Framework 3.5, https://www.microsoft.com/fr-fr/download/details.aspx?id=21

## Utilisation

* Télécharger le fichier Honeywell.Xenon.dll
* Inclué le dans les références dans votre projet .Net
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
