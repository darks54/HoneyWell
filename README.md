# HoneyWell

Lecteur d’imagerie matricielle Xenon 1900, http://country.honeywellaidc.com/fr-FR/Pages/Product.aspx?category=hand-held-barcode-scanner&cat=HSM&pid=1900

## Prérequis

* Microsoft .NET Framework 3.5, https://www.microsoft.com/fr-fr/download/details.aspx?id=21
* Installation du driver The Honeywell Scanning & Mobility (HSM), http://country.honeywellaidc.com/CatalogDocuments/HSM%20USB%20Serial%20Driver%20version%203.5.5.zip

## Utilisation

* Générez le projet Honeywell.Xenon
* Ajoutez dans les références de votre projet le fichier Honeywell.Xenon.dll
* Incluez-le dans les références dans votre projet .Net
```vb.net
Imports Honeywell.Xenon
```

### Lire un code barre
Pour lire un code barre, il suffit d'initialiser une instance de la classe Xenon en lui passant en paramètre le port COM utilisé par l'appareil. Le résultat sera envoyé automatiquement au focus même si celui-ci se trouve dans une autre application.
```vb.net
  Dim xenon As Xenon = New Xenon("COMx")
```

### Récupérer une image
Pour prendre une photo via votre lecteur de code barre Xenon 1900, commencez par initialiser la class Xenon a la création de votre class/form puis appelez la fonction GetImage en passant en paramètre le chemin et nom de l'image qui sera créée.
Vous pouvez également spécifier de multiple paramètre via IMGSNP et IMGSHP qui seront appliqué à vos images tant votre class Xenon existera.

Attention: certains paramètre ne sont pas compatible avec le modèle de base de l'appareil et nécessite le modèle Color.
```vb.net
Imports Honeywell.Xenon

Public Class Form1
    Dim xenon As Xenon = New Xenon("COMx")

    Private Sub btnJPG_Click(sender As Object, e As EventArgs) Handles btnJPG.Click
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If
        xenon.IMGSNP.LedState = True
        xenon.IMGSNP.Beeper = True
        xenon.IMGSNP.WaitForTrigger = True
        xenon.IMGSHP.FileFormat = FileFormat.JPEG
        xenon.IMGSHP.GammaCorrection = 70
        xenon.IMGSHP.EdgeSharpen = 18
        If xenon.GetImage("C:\temp\test.jpg") Then
            PictureBox1.Image = Image.FromFile("C:\temp\test.jpg")
        Else
            MsgBox("erreur")
        End If
    End Sub
	
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        xenon.Dispose()
    End Sub
End Class
```