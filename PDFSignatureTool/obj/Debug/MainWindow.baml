   M S B A M L   `   `   `  ����K  GPDFSignatureTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PDFSignatureToolPDFSignatureTool  5   	   !    PDFSignatureTool.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PDFSignatureTool     5   	     � Title$  Assinatura de PDF��5   	   $	��400��6$   $	��400��64   $	��700��6D   $	��700��6S   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��87* �6   �� 5      $
��485* �6   .+�5   
   �� -   5         ��Name$ lPasta��5      $��Pasta��6    $
��Left=�60   $��	10,22,0,0q�6K   $	��Top=�6^   $��54��6v    J� RenderTransformOrigin$ 0.481,-0.115&�6�   �� 5   
   -   5         ��Name$ bAssinarDocumentos��5      $��Assinar documentos��6-   $��1��6J   $
��Left=�6Z   $��433,140,0,0q�6u   $	��Top=�6�   $	��120��6�   $��23��6�   6�   �� 5   
   -   5        $ bLocalizarPasta��5      $��Localizar pasta��6-   $��1��6J   $
��Left=�6Z   $��
433,60,0,0q�6u   $	��Top=�6�   $	��120��6�   $��23��6�   6�   �� 5   
   -   5         ��Name$ tPasta��5      $��1��6"   $
��Left=�62   $��23��6M   $��5,22,0,0q�6Y    �� TextWrapping$
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��548��6�   �� 5   
   -   5        $ lCertificado��5      $��Certificado��6&   $
��Left=�6<   $��
10,100,0,0q�6W   $	��Top=�6k   $��69��6�   �� 5   
   -   5         ��Name$ cCertificado��5      $��1��6)   $
��Left=�69   $��	5,104,0,0q�6T   $	��Top=�6g   $	��548��6   6�   �� 5   
   -   5        $ tRestuldado��5      $��1��6'   $
��Left=�67   $	��155��6R   $��
10,186,0,0q�6_   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��543��6�   $
��Auto=�6�   �� 5   
   -   5        $ 
lResultado��5      $��	Resultado��6$   $
��Left=�68   $��
10,186,0,0q�6S   $	��Top=�6g   $��69��6   $ 0.377,5.577&�6�   5      5      