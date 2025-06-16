# GeniyIdiotNew - Тест на определение интеллекта

![ConsoleApp Screenshot](https://github.com/MagomedaliGajiev/GeniyIdiotNew/blob/master/ConsoleAppScreen.png) 
![WinformsApp Screenshot](https://github.com/MagomedaliGajiev/GeniyIdiotNew/blob/master/WinFormsAppScreen.png) 
*Примеры интерфейсов WinForms и консольной версии*

Юмористическое приложение для оценки интеллектуальных способностей с диагностикой от "кретина" до "гения". Реализовано в двух версиях: Windows Forms и консольной.

## 🌟 Особенности

- **Двойной интерфейс**: Графический (WinForms) и консольный режимы
- **Динамическое тестирование**: 10 секунд на ответ с визуализацией таймера
- **Управление вопросами**: Добавление/удаление тестовых вопросов
- **История результатов**: Сохранение и просмотр всех попыток
- **Автосохранение**: Данные хранятся в JSON-файлах между запусками
- **Диагностика**: 6 категорий интеллекта на основе процента правильных ответов

## ⚙️ Технологии

- .NET 6.0
- Windows Forms (GUI версия)
- JSON-сериализация (хранение данных)
- OOP принципы
- Multi-project solution

## 📦 Структура проекта

GeniyIdiotNew/
├── GeniyIdiotNew.Common/ # Общая логика
│ ├── Models/ # Классы данных
│ │ ├── User.cs
│ │ ├── Question.cs
│ │ └── UserResult.cs
│ ├── Repositories/ # Работа с данными
│ │ ├── QuestionsRepository.cs
│ │ └── UserResultsRepository.cs
│ ├── Services/ # Бизнес-логика
│ │ └── TestService.cs
│ └── Infrastructure/
│ └── FileProvider.cs # Утилиты работы с файлами
├── GeniyIdiotNewWinFormsApp/ # GUI приложение
│ ├── Forms/ # Окна приложения
│ │ ├── MainForm.cs # Главное меню
│ │ ├── TestForm.cs # Тестирование
│ │ ├── UserInfoForm.cs # Ввод данных пользователя
│ │ ├── ResultsForm.cs # Просмотр результатов
│ │ ├── QuestionsManagerForm.cs # Управление вопросами
│ │ └── AddQuestionForm.cs # Добавление вопроса
├── GeniyIdiotNewConsoleApp/ # Консольное приложение
│ └── Program.cs # Точка входа и логика

## 🚀 Запуск приложения

### Требования
- .NET 6.0 SDK
- Windows OS (для WinForms версии)

### Инструкция
1. Клонировать репозиторий:
   ```bash
   git clone https://github.com/your-username/GeniyIdiotNew.git

