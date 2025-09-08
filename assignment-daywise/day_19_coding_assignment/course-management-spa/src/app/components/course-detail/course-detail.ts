import { Component, Input } from '@angular/core';
import { Course } from '../../models/course';

@Component({
  selector: 'app-course-detail',
  standalone: false,
  templateUrl: './course-detail.html',
  styleUrl: './course-detail.css'
})
export class CourseDetail {
  @Input() course: Course | null = null;

}
