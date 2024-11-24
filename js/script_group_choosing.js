$(document).ready(function () {
  $(".menu-toggle").on("click", function () {
    $(".sidebar").toggleClass("hidden");
    $(".container").toggleClass("menu-closed");
  });
});

document.addEventListener('DOMContentLoaded', function() {
  // Пример данных, которые могут быть загружены из базы данных
  const subjects = [
      { name: 'Math', groups: ['Group 1', 'Group 2', 'Group 3'] },
      { name: 'Science', groups: ['Group 4', 'Group 5'] },
      { name: 'History', groups: ['Group 6'] }
  ];

  const subjectsList = document.getElementById('subjects-list');

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
});
