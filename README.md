# aashurov-EDSystems.CICD.CD

1. Git init 
    echo "# aashurov-EDSystems.CICD.CD" >> README.md
    git init
    git add README.md
    git commit -m "first commit"
    git branch -M main
    git remote add origin https://github.com/aashurov/EDSystems.CICD.CD.git
    git push -u origin main
    //This line for ssh
    git push git@github.com:aashurov/aashurov-EDSystems.CICD.CD.git   
    git remote set-url origin git@github.com:aashurov/EDSystems.CICD.CD.git
    ------------------------------------------
2. Set ssh sgent for github account 
   https://www.youtube.com/watch?v=nZYJKXXMvkM
   a. go to the https://github.com/settings/keys
   b. go to the https://docs.github.com/en/authentication/connecting-to-github-with-ssh
   c. ssh-keygen -t ed25519 -C "a.o.ashurov@gmail.com" type enter for all steps
   d. eval "$(ssh-agent -s)"
   f. open ~/.ssh/config
   e. if file not exist touch ~/.ssh/config
   g. Paste this line of code 
           Host *.github.com
                  AddKeysToAgent yes
                UseKeychain yes
                  IdentityFile ~/.ssh/id_ed25519
    h. ssh-add --apple-use-keychain ~/.ssh/id_ed25519
    i. go to the https://docs.github.com/en/authentication/connecting-to-github-with-ssh/adding-a-new-ssh-key-to-your-github-account
    j. pbcopy < ~/.ssh/id_ed25519.pub
    k. got to the https://github.com/settings/keys 
    l. Click new SSH key and paste from clipboard
    m. git remote set-url origin git@github.com:aashurov/ELogistics.CodeDeploy.git

3. Publich Aplication
    cd Desktop/MyFutureProjects/EDSystems.CICD.CD
    cd EDSystems.WebApi
    dotnet publish -o ../app

4. Create EC2 instance
    edsystems.cicd.cd.ec2
        * edsystems.cicd.cd.ec2.role
             - AmazonEC2RoleforAWSCodeDeployLimited

             for User Data section paste thi line of code
             #!/bin/bash
            echo "--------------------START----------------------"
            sudo yum install ruby -y
            sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm 
            sudo yum -y install aspnetcore-runtime-7.0 
            wget https://aws-codedeploy-us-east-2.s3.us-east-2.amazonaws.com/latest/install
            chmod +x ./install
            sudo ./install auto
            echo "--------------------FINISH----------------------"

5. For connection to EC2 
    chmod 400 ~/.ssh/EDSystems-KeyPair.pem
    ssh -i "~/.ssh/EDSystems-KeyPair.pem" ec2-user@ec2-3-89-251-183.compute-1.amazonaws.com

6. Create CodeDeploy
    elogistics.cdd.codedeploy (Code Deploy for ELogistics.CodeDeploy)
        elogistics.cdg.codedeploy (Code Deployment Group for ELogistics.CodeDeploy)
        elogistics.cdg.codedeploy.role (Role for Code Deployment Group for ELogistics.CodeDeploy)
          - AWSCodeDeployRole
          - AmazonS3FullAccess





sudo service codedeploy-agent status
tail -f /var/log/aws/codedeploy-agent/codedeploy-agent.log


ExecStart=/usr/bin/dotnet /var/aspnetcore/sample/sample.dll
ExecStart=/var/aspnetcore/sample/sample.dll

sudo systemctl daemon-reload
sudo systemctl restart edsystems.backend.service
sudo service edsystems.backend.service status


# EDSystems.CICD.CD
