   M S B A M L   `   `   `  ����E  AWorkerHaCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WorkerHaCS
WorkerHaCS  5   	   =#clr-namespace:WorkerHaCS.ConvertersWorkerHaCS.Converters  5   	       WorkerHaCS.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WorkerHaCS     5   	   :
converters#clr-namespace:WorkerHaCS.Converters     5   	   -   5          � Title$  
MainWindow��5
   	   $	��550��6   $
��1000��6)    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5      5  /WorkerHaCS.Converters.HouseInformationConverter   HouseInformationConverter,  &WorkerHaCS.Converters.PaymentConverter  PaymentConverter,  &WorkerHaCS.Converters.ServiceConverter  ServiceConverter+  %WorkerHaCS.Converters.StreetConverter  StreetConverter+  %WorkerHaCS.Converters.TenantConverter  TenantConverter,  &WorkerHaCS.Converters.AddressConverter  AddressConverter-  'WorkerHaCS.Converters.DateTimeConverter  DateTimeConverter��%�   &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r       5   
   6/     5   
   6&     5   
   6&     5   
   6%     5   
   6%     5   
   6&     5   
   6'   5      .��5      �   Grid#��[ 6    � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   .+�5   
   ��   
TabControl#��[ 6   .@�5      �� -   5         ��Name$ DepartmentTabItem��5   #   $��ЖЭС��6    	 AdditionalTabItem#��[	 6\   .��5      � #��[ 6   .+�5       ��  
 AdditionalTabControl#��[
 6!   .@�5!      �� -   5        $ TenantTabItem��5!   5   $��Арендатор��6"   #��[	 6L   $��0, -4, 0 ,0q�6�   .��5"      � $��0q�6#   $	��500��6.   $	��870��6;   .+�5#   "   &   System.Windows.Controls.DataGrid  -   5        $��TenantDataGrid��5#   +   $��10,10,30,70q�6A      AutoGenerateColumns$ False��6V      CanUserAddRows$ False��6r      CanUserDeleteRows$ False��6�   	   Columns	 5$   &   0	  *System.Windows.Controls.DataGridTextColumn	  5%   *   ,
  &System.Windows.Controls.DataGridColumn
 
  Header$
 Id��6=    
  
Visibility$ Hidden=�6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *Id+6`   	  5&   *   $
 Имя��6=    6J   �� *Name+	  5'   *   $
 Фамилия��6=    6N   �� *	Surname+	  5(   *   $
 Отчество��6=    6O   �� *
Patronymic+	  5)   *   $
 Телефон��6=    6N   �� *PhoneNumber+	  5*   *   $
 Лицевой счет��6=    6S   �� *
BankBook+4  .System.Windows.Controls.DataGridTemplateColumn  5+   *   $
 Оплаты��6A      CellTemplate 5,   .   �� 5-   2   .R�5.   6   �� -   5        .��5.   b   Открыть6k   5/   3   51   +   53   #   �� 54   "   -   5         ��Name$ TenantAddButton��54   )   $��Добавить��6B    
 Button#��[ 6U   $��10,409, 757,0q�6u   6�   �� 55   "   -   5        $ TenantChangeButton��55   )   $��Изменить��6E   #��[ 6X   $��10,409, 537,0q�6x   6�   �� 56   "   -   5        $ TenantDeleteButton��56   )   $��Удалить��6E   #��[ 6W   $��10,409, 317,0q�6w   6�   59      5:      �� 5;      -	   5        $ HouseInformationTabItem��5;   0   $��Дома��6"   #��[	 6Q   $��0, -4, 0 ,0q�6�   .��5<      � $��0q�6#   $	��500��6.   $	��870��6;   .+�5=   "     -
   5        $��HouseInformationDataGrid��5=   +   $��10,10,30,70q�6K   $ False��6`   $ False��6|   $ False��6�   	 5>   &   	  5?   *   $
 Id��6=   $ Hidden=�6`    6I   �� *Id+6`   	  5@   *   $
 
Улица��6=    6L   �� *
StreetId+ �� 	Converter# [  �� Mode$ TwoWay=�	  5A   *   $
 Номер дома��6=    6Q   �� *HouseNumber+	  5B   *   $)
 #Количество квартир��6=    6Y   �� *NumberOfApartments+5D   #   �� 5E   "   -   5        $ HouseInformationAddButton��5E   )   $��Добавить��6L   #��[ 6_   $��10,409, 757,0q�6   6�   �� 5F   "   -   5        $" HouseInformationChangeButton��5F   )   $��Изменить��6O   #��[ 6b   $��10,409, 537,0q�6�   6�   �� 5G   "   -   5        $" HouseInformationDeleteButton��5G   )   $��Удалить��6O   #��[ 6a   $��10,409, 317,0q�6�   6�   5H      5I      �� 5J      -   5        $ StreetTabItem��5J   1   $��
Улица��6"   #��[	 6H   $��0, -4, 0 ,0q�6�   .��5K      � $��0q�6#   $	��500��6.   $	��870��6;   .+�5L   "     -   5        $��StreetDataGrid��5L   +   $��10,10,30,70q�6A   $ False��6V   $ False��6r   $ False��6�   	 5M   &   	  5N   *   $
 Id��6=   $ Hidden=�6`    6I   �� *Id+6`   	  5O   *   $
 Название��6=    6O   �� *Name+5Q   #   �� 5R   "   -   5        $ StreetAddButton��5R   )   $��Добавить��6B   #��[ 6U   $��10,409, 757,0q�6u   6�   �� 5S   "   -   5        $ StreetChangeButton��5S   )   $��Изменить��6E   #��[ 6X   $��10,409, 537,0q�6x   6�   �� 5T   "   -   5        $ StreetDeleteButton��5T   )   $��Удалить��6E   #��[ 6W   $��10,409, 317,0q�6w   6�   5U      5V      �� 5W      -   5        $ RentApartmentTabItem��5W   2   $��Аренда��6"   #��[	 6P   $��0, -4, 0 ,0q�6�   .��5X      � $��0q�6#   $	��500��6.   $	��870��6;   .+�5Y   "     -   5        $��RentApartmentDataGrid��5Y   +   $��10,10,30,70q�6H   $ False��6]   $ False��6y   $ False��6�   	 5Z   &   	  5[   *   $
 Id��6=   $ Hidden=�6`    6I   �� *Id+6`   	  5\   *   $
 Арендатор��6=    6P   �� *
TenantId+# [ $ TwoWay=�	  5]   *   $1
 +Количество проживающих��6=    6]   �� *NumberOfResidents+	  5^   *   $
 Площадь��6=    6N   �� *Square+	  5_   *   $
 Номер дома��6=    6Q   �� *HouseInformationId+# [ $ TwoWay=�	  5`   *   $
 Квартира��6=    6O   �� *ApartmentNumber+5b   #   �� 5c   "   -   5        $ RentApartmentAddButton��5c   )   $��Добавить��6I   #��[ 6\   $��10,409, 757,0q�6|   6�   �� 5d   "   -   5        $ RentApartmentChangeButton��5d   )   $��Изменить��6L   #��[ 6_   $��10,409, 537,0q�6   6�   �� 5e   "   -   5        $ RentApartmentDeleteButton��5e   )   $��Удалить��6L   #��[ 6^   $��10,409, 317,0q�6~   6�   5f      5g      �� 5h      -   5        $ ServiceTabItem��5h   2   $��Услуга��6"   #��[	 6J   $��0, -4, 0 ,0q�6�   .��5i      � $��0q�6#   $	��500��6.   $	��870��6;   .+�5j   "     -   5        $��ServiceDataGrid��5j   +   $��10,10,30,70q�6B   $ False��6W   $ False��6s   $ False��6�   	 5k   &   	  5l   *   $
 Id��6=   $ Hidden=�6`    6I   �� *Id+6`   	  5m   *   $
 Код��6=    6J   �� *Code+	  5n   *   $
 Услуга��6=    6M   �� *Name+	  5o   *   $
 Ед. измерения��6=    6T   �� *Unit+	  5p   *   $
 Тариф, руб.��6=    6R   �� *Rate+5r   #   �� 5s   "   -   5        $ ServiceAddButton��5s   )   $��Добавить��6C   #��[ 6V   $��10,409, 757,0q�6v   6�   �� 5t   "   -   5        $ ServiceChangeButton��5t   )   $��Изменить��6F   #��[ 6Y   $��10,409, 537,0q�6y   6�   �� 5u   "   -   5        $ ServiceDeleteButton��5u   )   $��Удалить��6F   #��[ 6X   $��10,409, 317,0q�6x   6�   5v      5w      �� 5x      -   5        $ PaymentForServiceTabItem��5x   8   $��Оплата услуг��6"   #��[	 6Z   $��0, -4, 0 ,0q�6�   .��5y      � $��0q�6#   $	��500��6.   $	��870��6;   .+�5z   "     -   5        $��PaymentForServiceDataGrid��5z   +   $��10,10,30,70q�6L   $ False��6a   $ False��6}   $ False��6�   	 5{   &   	  5|   *   $
 Id��6=   $ Hidden=�6`    6I   �� *Id+6`   	  5}   *   $
 Арендатор��6=    6P   �� *
TenantId+# [ $ TwoWay=�	  5~   *   $
 Услуга��6=    6M   �� *	ServiceId+# [ $ TwoWay=�	  5   *   $&
  Сумма оплаты, руб.��6=    6Y   �� *ActuallySpent+	  5�   *   $
 Дата оплаты��6=    6R   �� *DateOfPayment+# [ $ TwoWay=�	  5�   *   $
 В срок оплата��6=    6T   �� *	PaymentId+# [ $ TwoWay=�5�   #   �� 5�   "   -   5        $  PaymentForServiceAddButton��5�   )   $��Добавить��6M   #��[ 6`   $��10,409, 757,0q�6�   6�   �� 5�   "   -    5        $# PaymentForServiceChangeButton��5�   )   $��Изменить��6P   #��[ 6c   $��10,409, 537,0q�6�   6�   �� 5�   "   -!   5        $# PaymentForServiceDeleteButton��5�   )   $��Удалить��6P   #��[ 6b   $��10,409, 317,0q�6�   6�   �� 5�   "   -"   5        $ OpenDeptorButton��5�   )   $��Долг��6C   #��[ 6R   $��0,440,-710,30q�6r   6�   5�      5�      5�      5�      5�      5�      5�      5�      