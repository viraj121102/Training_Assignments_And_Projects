import { Component, signal } from '@angular/core';
import { Course } from './models/course';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('course-management-spa');
  courses: Course[] = [
    { id: 1, title: 'Angular Basics', category: 'Frontend', description: 'Intro to components, templates, and data binding.' },
    { id: 2, title: 'TypeScript Fundamentals', category: 'Language', description: 'Types, interfaces, generics, and tooling.' },
    { id: 3, title: 'RxJS Essentials', category: 'Reactive', description: 'Streams, operators, and reactive patterns.' },
  ];

  selectedCourse: Course | null = null;

  onCourseSelected(course: Course) {
    this.selectedCourse = course;
  }

}
