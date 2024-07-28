# .NET и SQL

## Задание
	1. Напишите на C# библиотеку для поставки внешним клиентам
	Код в master ветке
	
	2.  Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории»
	`SELECT p.ProductName, c.CategoryName
	 FROM Products p
	 LEFT JOIN ProductCategories pc ON p.ProductID = pc.ProductID
	 LEFT JOIN Categories c ON pc.CategoryID = c.CategoryID
	 ORDER BY p.ProductName;`

