$(document).ready(function () {
    $(".menu-toggle").on("click", function () {
        $(".sidebar").toggleClass("hidden");
        $(".container").toggleClass("menu-closed");
      });
    const toggleMenuButton = $('.toggle-menu'); // Кнопка меню
    const analysisTools = $('.analysis-tools'); // Меню справа

    // Обработчик клика на кнопку меню
    toggleMenuButton.on('click', function () {
        analysisTools.toggleClass('active'); // Выдвижение/убирание меню
        toggleMenuButton.toggleClass('active'); // Обновление положения кнопки
    });
    const students = [
        'Широкок', 'Глеб', 'Ванен', 'Скуф', 'Шнырь',
        'Димен', 'Трофикок', 'КОЧИН', 'Касимыч', 'Шнырь 2.0',
        'Влад Гойдин', 'Яна Цист'
    ];
    const dates = [
        '2023-10-01', '2023-10-02', '2023-10-03', '2023-10-04', '2023-10-05'
    ];
    const attendanceData = {
        'Широкок': {
            '2023-10-01': 'Был', '2023-10-02': 'Не был', '2023-10-03': 'Был', '2023-10-04': 'Был', '2023-10-05': 'Не был'
        },
        'Глеб': {
            '2023-10-01': 'Был', '2023-10-02': 'Был', '2023-10-03': 'Не был', '2023-10-04': 'Был', '2023-10-05': 'Был'
        },
        'Ванен': {
            '2023-10-01': 'Не был', '2023-10-02': 'Был', '2023-10-03': 'Был', '2023-10-04': 'Не был', '2023-10-05': 'Был'
        },
        'Скуф': {
            '2023-10-01': 'Был', '2023-10-02': 'Не был', '2023-10-03': 'Был', '2023-10-04': 'Был', '2023-10-05': 'Не был'
        },
        'Шнырь': {
            '2023-10-01': 'Был', '2023-10-02': 'Был', '2023-10-03': 'Не был', '2023-10-04': 'Был', '2023-10-05': 'Был'
        },
        'Димен': {
            '2023-10-01': 'Не был', '2023-10-02': 'Был', '2023-10-03': 'Был', '2023-10-04': 'Не был', '2023-10-05': 'Был'
        },
        'Трофикок': {
            '2023-10-01': 'Был', '2023-10-02': 'Не был', '2023-10-03': 'Был', '2023-10-04': 'Был', '2023-10-05': 'Не был'
        },
        'КОЧИН': {
            '2023-10-01': 'Был', '2023-10-02': 'Был', '2023-10-03': 'Не был', '2023-10-04': 'Был', '2023-10-05': 'Был'
        },
        'Касимыч': {
            '2023-10-01': 'Не был', '2023-10-02': 'Был', '2023-10-03': 'Был', '2023-10-04': 'Не был', '2023-10-05': 'Был'
        },
        'Шнырь 2.0': {
            '2023-10-01': 'Был', '2023-10-02': 'Не был', '2023-10-03': 'Был', '2023-10-04': 'Был', '2023-10-05': 'Не был'
        },
        'Влад Гойдин': {
            '2023-10-01': 'Был', '2023-10-02': 'Не был', '2023-10-03': 'Был', '2023-10-04': 'Был', '2023-10-05': 'Не был'
        },
        'Яна Цист': {
            '2023-10-01': 'Был', '2023-10-02': 'Не был', '2023-10-03': 'Был', '2023-10-04': 'Был', '2023-10-05': 'Не был'
        }
    };

    // Создание таблицы посещаемости
    function createAttendanceTable(students, dates, attendanceData) {
        dates.forEach(date => {
            $('#attendanceTable thead tr').append(`<th>${date}</th>`);
        });

        students.forEach(student => {
            let row = `<tr><td>${student}</td>`;
            dates.forEach(date => {
                row += `<td>${attendanceData[student][date] || ''}</td>`;
            });
            row += '</tr>';
            $('#attendanceTable tbody').append(row);
        });
    }

    createAttendanceTable(students, dates, attendanceData);
});
document.addEventListener('DOMContentLoaded', function() {
    function createSubjectsList(subjects) {
        const subjectsList = document.getElementById('subjects-list');
        subjectsList.innerHTML = ''; // Очищаем список перед добавлением новых элементов
  
        subjects.forEach(subject => {
            const subjectItem = document.createElement('li');
            subjectItem.className = 'subject-item';
  
            const subjectTitle = document.createElement('h2');
            subjectTitle.textContent = subject.name;
            subjectItem.appendChild(subjectTitle);
  
            const groupList = document.createElement('ul');
            groupList.className = 'group-list';
  
            subject.groups.forEach(group => {
                const groupItem = document.createElement('li');
                groupItem.className = 'group-item';
  
                const groupTitle = document.createElement('h3');
                groupTitle.textContent = group;
                groupItem.appendChild(groupTitle);
  
                groupItem.addEventListener('click', () => {
                    alert(`Subject: ${subject.name}, Group: ${group}`);
                });
  
                groupList.appendChild(groupItem);
            });
  
            subjectItem.appendChild(groupList);
            subjectsList.appendChild(subjectItem);
  
            subjectItem.addEventListener('click', () => {
                const isOpen = groupList.style.maxHeight === '500px';
                groupList.style.maxHeight = isOpen ? '0' : '500px';
                groupList.style.display = isOpen ? 'none' : 'block';
            });
        });
    }
  
    // Пример данных, которые могут быть загружены из базы данных
    const subjects = [
        { name: 'Math', groups: ['Group 1', 'Group 2', 'Group 3'] },
        { name: 'Science', groups: ['Group 4', 'Group 5'] },
        { name: 'History', groups: ['Group 6'] }
    ];
  
    // Вызов функции с примером данных
    createSubjectsList(subjects);
  });
  