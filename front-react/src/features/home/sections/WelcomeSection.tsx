import * as React from 'react';
import Stack from "@mui/joy/Stack";
import Box from "@mui/joy/Box";
import Typography from "@mui/joy/Typography";
import SafePicture from "../../../../public/images/picture_safe.png"
import Button from "@mui/joy/Button";
import {redirect} from 'next/navigation'
import ButtonLink from "@/features/home/sections/components/ButtonLink";
export const WelcomeSection = () => {
    return (
        <section>
            <Stack
                sx={{
                    height: '100lvh',
                    display: 'flex',
                    flexDirection: 'row',
                    alignItems: 'center',
                }}
            >
                <Box>
                    <Typography
                        sx={{
                            fontSize: '120px',
                            fontWeight: '700',
                        }}
                    >Turbinance</Typography>
                    <Typography

                    >
                        Welcome to our charitable online auction web-site! We've created this platform to provide
                        charitable organizations, users, and businesses with the opportunity to auction a diverse range
                        of items and services to raise funds for charitable initiatives. Register or log in to our
                        website to take part in real-time auctions. Explore a world of giving on our charitable online
                        auction platform. Every bid you make becomes a meaningful contribution to causes that make a
                        difference.
                    </Typography>
                    <Box sx={{
                        display: 'flex',
                        justifyContent: 'center',
                        paddingY: '1rem',
                    }}>
                        <ButtonLink
                            href={"/auctions"}
                            size={'lg'}
                        >
                            View Auctions
                        </ButtonLink>
                    </Box>
                </Box>
                <img src={SafePicture.src} alt="safe"
                     style={{
                         // width: '40rem',
                         height: '40rem',
                         // position: 'absolute'
                     }}
                     // className={'relative lg:static'}
                />
            </Stack>
        </section>
    );
};