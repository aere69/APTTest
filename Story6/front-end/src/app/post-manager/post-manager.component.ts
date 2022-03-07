import { Component, OnInit } from '@angular/core';
import { PostsService } from '../posts.service';
import { Post } from '../post';
import { saveAs  } from "file-saver"


@Component({
  selector: 'app-post-manager',
  templateUrl: './post-manager.component.html',
  styleUrls: ['./post-manager.component.css']
})
export class PostManagerComponent implements OnInit {

  posts : Post[] = [];
  errorMessage = '';
  downloadFilePath = '';
  post = { postId: 0, fileName: '', totalAmount: 0 };

  constructor(private postsService: PostsService) { }

  ngOnInit(): void {
    this.fetchPosts();
  }

  fetchPosts(): void {
    this.postsService.getPosts()
      .then(posts => this.posts = posts,
        error => this.errorMessage = error);
  }

  downloadDetails(): void {
    this.postsService.getDetails(this.post.postId)
      .then(string => {
        this.downloadFilePath = string;
        saveAs(this.downloadFilePath, "file.csv");
      },
        error => this.errorMessage = error);
  }
}
