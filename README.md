# Mentoring.Lab8.Task2

## Задание #2 к модулю HTTPfundamentals

## Задание

Написать HTTPhandler, генерирующий отчет по заказам в базе Northwind.

Handler должен уметь:

- Принимать параметры:
  - в виде строки запроса (т.е. вида [http](http://host/Report?param1=value1&amp;param1)[://](http://host/Report?param1=value1&amp;param1)[host](http://host/Report?param1=value1&amp;param1)[/](http://host/Report?param1=value1&amp;param1)[Report](http://host/Report?param1=value1&amp;param1)[?](http://host/Report?param1=value1&amp;param1)[param](http://host/Report?param1=value1&amp;param1)[1=](http://host/Report?param1=value1&amp;param1)[value](http://host/Report?param1=value1&amp;param1)[1&amp;param1](http://host/Report?param1=value1&amp;param1)=...)
  - или в теле запроса (в формате application/x-www-form-urlencoded)
- Поддерживать параметры:
  - customer – ID заказчика
  - dateFrom / dateTo – период дат на которые нужно выдать заказы (заказы фильтруются по дате OrderDate включительно). Может быть указан только 1 параметер
  - take – сколько заказов вернуть.
  - skip – сколько заказов пропустить

**В отчете заказы упорядочиваются по**  **OrderID****!**

Любой из перечисленных параметров может быть пропущен, в этом случае определяемое им условие выборки не применяется.

- Анализировать заголовок Accept и возвращать отчет в следующих форматах

| Accept | Формат |
| --- | --- |
| application/vnd.openxmlformats-officedocument.spreadsheetml.sheet | Excel (.xlsx) |
| text/xml | XML |
|  application/xml | XML |
| Любой другой или вовсе отсутствует | Excel (.xlsx) |

- Указывать в ответе правильный Content-Type (так, чтобы при открытии из браузера – открывался нужный редактор/просмотрщик)

Для тестирования handler напишите набор интеграционных тестов, работающих поверх HttpClient и проверяющих различные варианты вызова handler.

## Замечания по реализации

Состав возвращаемых из базы Order полей, а также структуру XML – определяете сами.

Для формирования Excel можно использовать

- [OpenXML SDK](https://www.nuget.org/packages/DocumentFormat.OpenXml/)
- Но рекомендуется воспользоваться более простым [ClosedXML](https://github.com/closedxml/closedxml)
