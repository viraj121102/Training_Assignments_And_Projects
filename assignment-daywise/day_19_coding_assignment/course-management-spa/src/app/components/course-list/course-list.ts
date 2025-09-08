import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Course } from '../../models/course';

@Component({
  selector: 'app-course-list',
  standalone: false,
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList {
  @Input() courses: Course[] = [];
  @Output() courseSelected = new EventEmitter<Course>();

  selectCourse(course: Course) {
    this.courseSelected.emit(course);
  }

}
