export interface User {
  username: string;
  email: string;
  givenName?: string;
  surname?: string;
  role: string;
}

export interface UserDto {
  username: string;
  password: string;
}

export interface UserDisplayDto {
  username: string;
  role: string;
} 