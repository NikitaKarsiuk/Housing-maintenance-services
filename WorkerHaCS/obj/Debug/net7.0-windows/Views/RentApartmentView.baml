   M S B A M L   `   `   `  ����E  AWorkerHaCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WorkerHaCS.ViewsWorkerHaCS.Views  5   	   (    "WorkerHaCS.Views.RentApartmentView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WorkerHaCS.Views     5   	     � Title$   ��5   	   $	��305��6   $	��355��6    � 
ResizeMode$ NoResize=�5	   	   .��5
      � .+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5      �� .��6   Арендатор6#   �� 5      -   5         ��Name$ TenantComboBox��5       �� DisplayMemberPath$ BankBook��63   $��64, 0, -244, 0q�6Q   $	��199��6i   5      �� 5      $ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5      �� .��6   $"Кол-во проживающих6,   �� 5      -   5         ��Name$ NumberOfResidentsTextBox��5         TextBox#��[  6=   $��
0, 0, 0, 0q�6^   $	��199��6r   5      �� 5      $ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5      �� .��6   Площадь6!   �� 5      -   5        $ SquareTextBox��5      #��[  61   $��73, 0, 0, 0q�6R   $	��199��6g   5      �� 5      $ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5      �� .��6   
Улица6   �� 5      -   5        $ StreetComboBox��5      $
 Name��63   $��90, 0, 0, 0q�6L   $	��199��6a   6m   5      �� 5      $ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5      �� .��6   Дом6   �� 5      -   5        $ HouseNumberComboBox��5      $ HouseNumber��68   $��100, 0, 0, 0q�6X   $	��199��6n   5      �� 5       $ 
Horizontal=�6   $��0, 10, 0, 0q�62   .+�5!      �� .��6   Номер квартиры6(   �� 5"      -   5        $ ApartmentNumberTextBox��5"      #��[  6;   $��30, 0, 0, 0q�6\   $	��199��6q   5#      �� 5%      -   5         ��Name$ 
SaveButton��5%       
 Button#��[ 6)   $��Сохранить��6I   $��0,10,0,0q�6^   6p   5&      5'      5(      